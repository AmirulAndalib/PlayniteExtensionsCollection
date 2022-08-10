﻿using Playnite.SDK;
using Playnite.SDK.Models;
using PlayState.Controls;
using PlayState.Enums;
using PlayState.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PlayState.ViewModels
{
    public class PlayStateManagerViewModel : ObservableObject
    {
        public event EventHandler GameStatusSwitched;

        private readonly IPlayniteAPI playniteApi;
        private readonly MessagesHandler messagesHandler;
        private PlayStateSettingsViewModel settings;
        public PlayStateSettingsViewModel Settings { get => settings; private set => SetValue(ref settings, value); }
        private Guid CurrentDetectionId = Guid.Empty;
        private Game currentGame;
        public Game CurrentGame { get => currentGame; private set => SetValue(ref currentGame, value); }
        private bool isSelectedDataCurrentGame = false;
        public bool IsSelectedDataCurrentGame { get => isSelectedDataCurrentGame; set => SetValue(ref isSelectedDataCurrentGame, value); }
        public PlayStateData selectedData { get; set; }
        public PlayStateData SelectedData
        {
            get => selectedData;
            set
            {
                selectedData = value;
                if (selectedData == null || CurrentGame == null)
                {
                    IsSelectedDataCurrentGame = false;
                }
                else
                {
                    IsSelectedDataCurrentGame = GetIsCurrentGameSame(selectedData.Game);
                }

                OnPropertyChanged();
            }
        }

        private ObservableCollection<PlayStateData> playStateDataCollection;
        public ObservableCollection<PlayStateData> PlayStateDataCollection { get => playStateDataCollection; set => SetValue(ref playStateDataCollection, value); }

        private readonly DispatcherTimer automaticStateUpdateTimer;
        private static readonly ILogger logger = LogManager.GetLogger();
        private Dictionary<Guid, string> detectionDictionary = new Dictionary<Guid, string>();
        private Dictionary<IntPtr, string> openWindows;
        private bool openWindowsUpdated = false;

        public PlayStateManagerViewModel(IPlayniteAPI playniteApi, PlayStateSettingsViewModel playStateSettings, MessagesHandler messagesHandler)
        {
            this.playniteApi = playniteApi;
            this.messagesHandler = messagesHandler;
            Settings = playStateSettings;
            PlayStateDataCollection = new ObservableCollection<PlayStateData>();
            automaticStateUpdateTimer = new DispatcherTimer();
            automaticStateUpdateTimer.Interval = TimeSpan.FromMilliseconds(4000);
            automaticStateUpdateTimer.Tick += new EventHandler(UpdateAutomaticStates);
        }

        private void SetAutomaticStateUpdaterTimer()
        {
            if (playStateDataCollection.HasItems())
            {
                automaticStateUpdateTimer.Start();
            }
            else
            {
                automaticStateUpdateTimer.Stop();
            }
        }

        private void UpdateAutomaticStates(object sender, EventArgs e)
        {
            if (!settings.Settings.UseForegroundAutomaticSuspend || !playStateDataCollection.HasItems())
            {
                return;
            }

            openWindowsUpdated = false;
            var foregroundWindowHandle = WindowsHelper.GetForegroundWindowHandle();
            foreach (var playstateData in PlayStateDataCollection)
            {
                if (!playstateData.HasProcesses)
                {
                    continue;
                }
                
                var isForeground = playstateData.GameProcesses.Any(x => x.Process.MainWindowHandle == foregroundWindowHandle);
                if (!playstateData.HasBeenInForeground && isForeground)
                {
                    playstateData.HasBeenInForeground = true;
                }

                if (!ContinueAutomaticStateExecution(playstateData, isForeground))
                {
                    continue;
                }

                if (isForeground == playstateData.IsSuspended)
                {
                    SwitchGameState(playstateData);
                }
            }
        }

        private bool ContinueAutomaticStateExecution(PlayStateData playstateData, bool isForeground)
        {
            if (playstateData.SuspendMode != SuspendModes.Processes)
            {
                return true;
            }

            // We check if the game window has been in the foreground at least once. This is done to
            // prevent suspending the game processes automatically before they are still in loading state
            // and have not even shown their game windows. Mostly intended for games with long startup times
            if (!playstateData.HasBeenInForeground)
            {
                return false;
            }

            // We check if the game window is open to prevent suspending a game process whose window
            // is not being displayed, which can cause issues. Instances of this could be when a game
            // is in exit procedure, has closed its window but is still running
            if (!isForeground && !playstateData.IsSuspended)
            {
                if (!openWindowsUpdated)
                {
                    openWindows = WindowsHelper.GetOpenWindows();
                    openWindowsUpdated = true;
                }

                if (!openWindows.Any(x => playstateData.GameProcesses.Any(y => y.Process.MainWindowHandle == x.Key)))
                {
                    logger.Debug($"Game {playstateData.Game.Name} was not in foreground but its window could not be found");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method for obtaining the gameData of the asked game.
        /// </summary>
        internal PlayStateData GetDataOfGame(Game game)
        {
            return GetDataOfGameFromId(game.Id);
        }

        internal PlayStateData GetDataOfGameFromId(Guid id)
        {
            return playStateDataCollection.FirstOrDefault(x => x.Game.Id == id);
        }

        internal void AddPlayStateData(Game game, SuspendModes suspendMode, List<ProcessItem> gameProcesses, bool setAsCurrentGame = true)
        {
            if (playStateDataCollection.Any(x => x.Game.Id == game.Id))
            {
                logger.Debug($"Data for game {game.Name} with id {game.Id} already exists");
            }
            else
            {
                playStateDataCollection.Add(new PlayStateData(game, gameProcesses, suspendMode));
                var procsExecutablePaths = string.Join(", ", gameProcesses.Select(x => x.ExecutablePath));
                logger.Debug($"Data for game {game.Name} with id {game.Id} was created. Executables: {procsExecutablePaths}");
            }

            RemoveGameFromDetection(game);
            if (setAsCurrentGame)
            {
                CurrentGame = game;
                logger.Debug($"Changed current game to {game.Name}");
            }

            SetAutomaticStateUpdaterTimer();
        }

        public void RemovePlayStateData(Game game)
        {
            var data = GetDataOfGame(game);
            if (data != null)
            {
                RemovePlayStateData(data);
            }
        }

        public void RemovePlayStateData(PlayStateData gameData)
        {
            playStateDataCollection.Remove(gameData);
            logger.Debug($"Data for game {gameData.Game.Name} with id {gameData.Game.Id} was removed");
            if (CurrentGame == gameData.Game)
            {
                CurrentGame = playStateDataCollection.Any() ? playStateDataCollection.Last().Game : null;
                if (SelectedData != null)
                {
                    IsSelectedDataCurrentGame = GetIsCurrentGameSame(SelectedData.Game);
                }
            }

            SetAutomaticStateUpdaterTimer();
        }

        public PlayStateData GetCurrentGameData()
        {
            if (CurrentGame == null)
            {
                return null;
            }

            return GetDataOfGame(CurrentGame);
        }

        public bool GetIsCurrentGameDifferent(Game game)
        {
            if (CurrentGame == null || CurrentGame.Id != game.Id)
            {
                return true;
            }

            return false;
        }

        public bool GetIsCurrentGameSame(Game game)
        {
            if (CurrentGame == null)
            {
                return false;
            }

            return CurrentGame.Id == game.Id;
        }

        public bool? GetIsGameSuspended(Game game)
        {
            var data = GetDataOfGame(game);
            if (data != null)
            {
                return data.IsSuspended;
            }

            return null;
        }

        public RelayCommand NavigateBackCommand
        {
            get => new RelayCommand(() =>
            {
                playniteApi.MainView.SwitchToLibraryView();
            });
        }

        public RelayCommand SwitchGameStateCommand
        {
            get => new RelayCommand (() =>
            {
                if (SelectedData != null)
                {
                    SwitchGameState(SelectedData);
                }
            });
        }

        public RelayCommand<Guid> SwitchGameStateFromIdCommand
        {
            get => new RelayCommand<Guid>((a) =>
            {
                SwitchGameStateFromId(a);
            });
        }

        public RelayCommand<PlayStateData> SwitchGameBindingStateCommand
        {
            get => new RelayCommand<PlayStateData>((a) =>
            {
                if (a != null)
                {
                    SwitchGameState(a);
                }
            });
        }

        public RelayCommand SetActiveGameCommand
        {
            get => new RelayCommand(() =>
            {
                if (SelectedData != null)
                {
                    CurrentGame = SelectedData.Game;
                    IsSelectedDataCurrentGame = GetIsCurrentGameSame(SelectedData.Game);
                }
            });
        }

        public RelayCommand<PlayStateData> SetActiveGameBindingStateCommand
        {
            get => new RelayCommand<PlayStateData>((a) =>
            {
                if (a != null)
                {
                    CurrentGame = a.Game;
                }
            });
        }

        public void SwitchGameState(Game game)
        {
            SwitchGameStateFromId(game.Id);
        }

        public void SwitchGameStateFromId(Guid id)
        {
            var playstateData = GetDataOfGameFromId(id);
            if (playstateData != null)
            {
                SwitchGameState(playstateData);
            }
        }

        public void CloseCurrentGame()
        {
            var gameData = GetCurrentGameData();
            if (gameData == null || !gameData.HasProcesses)
            {
                return;
            }

            ProcessesHandler.CloseProcessItem(gameData.GameProcesses);
        }

        public void ShowCurrentGameStatusNotification()
        {
            var gameData = GetCurrentGameData();
            if (gameData != null)
            {
                messagesHandler.ShowGameStatusNotification(NotificationTypes.Information, gameData, true);
            }
        }

        public void SwitchCurrentGameState()
        {
            var gameData = GetCurrentGameData();
            if (gameData != null)
            {
                SwitchGameState(gameData);
            }
        }

        public void SwitchGameState(PlayStateData gameData)
        {
            try
            {
                var processesSuspended = false;
                if (gameData.SuspendMode == SuspendModes.Processes && gameData.GameProcesses.HasItems())
                {
                    foreach (var gameProcess in gameData.GameProcesses)
                    {
                        if (gameProcess == null || gameProcess.Process.Handle == null || gameProcess.Process.Handle == IntPtr.Zero)
                        {
                            return;
                        }
                        if (gameData.IsSuspended)
                        {
                            ProcessesHandler.NtResumeProcess(gameProcess.Process.Handle);
                        }
                        else
                        {
                            ProcessesHandler.NtSuspendProcess(gameProcess.Process.Handle);
                        }
                    }

                    processesSuspended = true;
                }

                if (processesSuspended || gameData.SuspendMode == SuspendModes.Playtime)
                {
                    if (gameData.IsSuspended)
                    {
                        gameData.IsSuspended = false;
                        if (processesSuspended)
                        {
                            messagesHandler.ShowGameStatusNotification(NotificationTypes.Resumed, gameData);
                        }
                        else
                        {
                            messagesHandler.ShowGameStatusNotification(NotificationTypes.PlaytimeResumed, gameData);
                        }

                        gameData.Stopwatch.Stop();
                        logger.Debug($"Game {gameData.Game.Name} resumed in mode {gameData.SuspendMode}");
                    }
                    else
                    {
                        gameData.IsSuspended = true;
                        if (processesSuspended)
                        {
                            messagesHandler.ShowGameStatusNotification(NotificationTypes.Suspended, gameData);
                        }
                        else
                        {
                            messagesHandler.ShowGameStatusNotification(NotificationTypes.PlaytimeSuspended, gameData);
                        }

                        gameData.Stopwatch.Start();
                        logger.Debug($"Game {gameData.Game.Name} suspended in mode {gameData.SuspendMode}");
                    }
                }

                GameStatusSwitched(null, null);
                if (settings.Settings.BringResumedToForeground && !gameData.IsSuspended)
                {
                    BringGameWindowToFront(gameData);
                }
            }
            catch (Exception e)
            {
                logger.Error(e, $"Error while suspending or resuming game {gameData.Game.Name} in mode {gameData.SuspendMode}");
                gameData.GameProcesses = null;
                gameData.Stopwatch.Stop();
            }

            automaticStateUpdateTimer.Stop();
            automaticStateUpdateTimer.Start();
        }

        private void BringGameWindowToFront(PlayStateData playstateData)
        {
            if (!playstateData.HasProcesses)
            {
                return;
            }
            
            var foregroundWindowHandle = WindowsHelper.GetForegroundWindowHandle();

            // Check if game window is already in foreground
            if (playstateData.GameProcesses.Any(x => x.Process.MainWindowHandle == foregroundWindowHandle))
            {
                return;
            }

            var processItem = playstateData.GameProcesses
                .FirstOrDefault(x => x.Process.MainWindowHandle != null && x.Process.MainWindowHandle != IntPtr.Zero);
            if (processItem == null)
            {
                return;
            }

            var windowHandle = processItem.Process.MainWindowHandle;
            try
            {
                WindowsHelper.RestoreAndFocusWindow(windowHandle);
            }
            catch (Exception e)
            {
                logger.Error(e, $"Error while restoring game window of game {playstateData.Game.Name}, {windowHandle}");
            }
        }

        internal void AddGameToDetection(Game game)
        {
            detectionDictionary.Add(game.Id, game.Name);
            logger.Debug($"Added game {game.Name} with Id {game.Id} to detection dictionary");
        }

        internal bool RemoveGameFromDetection(Game game)
        {
            var removed = detectionDictionary.Remove(game.Id);
            if (removed)
            {
                logger.Debug($"Removed game {game.Name} with Id {game.Id} from detection dictionary");
            }

            return removed;
        }

        internal bool IsGameBeingDetected(Game game)
        {
            return detectionDictionary.ContainsKey(game.Id);
        }

        internal bool IsGameInDataCollectionFromId(Guid id)
        {
            return PlayStateDataCollection.Any(x => x.Game.Id == id);
        }

        public PlayStateDataStatus GetStatusOfGame(Game game)
        {
            return GetStatusOfGameFromId(game.Id);
        }

        public PlayStateDataStatus GetStatusOfGameFromId(Guid id)
        {
            var playstateData = GetDataOfGameFromId(id);
            if (playstateData != null)
            {
                if (playstateData.IsSuspended)
                {
                    return PlayStateDataStatus.Paused;
                }
                else
                {
                    return PlayStateDataStatus.Running;
                }
            }

            return PlayStateDataStatus.NotFound;
        }
    }
}