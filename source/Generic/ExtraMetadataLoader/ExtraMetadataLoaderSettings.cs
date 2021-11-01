﻿using Playnite.SDK;
using Playnite.SDK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExtraMetadataLoader
{
    public class ExtraMetadataLoaderSettings : ObservableObject
    {
        [DontSerialize]
        private bool enableVideoPlayer { get; set; } = true;
        public bool EnableVideoPlayer
        {
            get => enableVideoPlayer;
            set
            {
                enableVideoPlayer = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool autoPlayVideos { get; set; } = false;
        public bool AutoPlayVideos
        {
            get => autoPlayVideos;
            set
            {
                autoPlayVideos = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool repeatTrailerVideos { get; set; } = false;
        public bool RepeatTrailerVideos
        {
            get => repeatTrailerVideos;
            set
            {
                repeatTrailerVideos = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool startNoSound { get; set; } = false;
        public bool StartNoSound
        {
            get => startNoSound;
            set
            {
                startNoSound = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool useMicrotrailersDefault { get; set; } = false;
        public bool UseMicrotrailersDefault
        {
            get => useMicrotrailersDefault;
            set
            {
                useMicrotrailersDefault = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool fallbackVideoSource { get; set; } = true;
        public bool FallbackVideoSource
        {
            get => fallbackVideoSource;
            set
            {
                fallbackVideoSource = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool streamSteamVideosOnDemand { get; set; } = true;
        public bool StreamSteamVideosOnDemand
        {
            get => streamSteamVideosOnDemand;
            set
            {
                streamSteamVideosOnDemand = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool streamSteamHighQuality { get; set; } = false;
        public bool StreamSteamHighQuality
        {
            get => streamSteamHighQuality;
            set
            {
                streamSteamHighQuality = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool showControls { get; set; } = true;
        public bool ShowControls
        {
            get => showControls;
            set
            {
                showControls = value;
                OnPropertyChanged();
            }
        }
        [DontSerialize]
        private double defaultVolume { get; set; } = 100;
        public double DefaultVolume
        {
            get => defaultVolume;
            set
            {
                defaultVolume = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private double videoControlsOpacity { get; set; } = 0.3;
        public double VideoControlsOpacity
        {
            get => videoControlsOpacity;
            set
            {
                videoControlsOpacity = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private double videoControlsOpacityMouseOver { get; set; } = 1.0;
        public double VideoControlsOpacityMouseOver
        {
            get => videoControlsOpacityMouseOver;
            set
            {
                videoControlsOpacityMouseOver = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private VerticalAlignment videoControlsVerticalAlignment { get; set; } = VerticalAlignment.Bottom;
        public VerticalAlignment VideoControlsVerticalAlignment
        {
            get => videoControlsVerticalAlignment;
            set
            {
                videoControlsVerticalAlignment = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool enableLogos { get; set; } = true;
        public bool EnableLogos
        {
            get => enableLogos;
            set
            {
                enableLogos = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private double logoMaxWidth { get; set; } = 600;
        public double LogoMaxWidth
        {
            get => logoMaxWidth;
            set
            {
                logoMaxWidth = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private double logoMaxHeight { get; set; } = 200;
        public double LogoMaxHeight
        {
            get => logoMaxHeight;
            set
            {
                logoMaxHeight = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool logosEnableShadowEffect { get; set; } = true;
        public bool LogosEnableShadowEffect
        {
            get => logosEnableShadowEffect;
            set
            {
                logosEnableShadowEffect = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private double logosShadowDepth { get; set; } = 0;
        public double LogosShadowDepth
        {
            get => logosShadowDepth;
            set
            {
                logosShadowDepth = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private double logosShadowDirection { get; set; } = 0;
        public double LogosShadowDirection
        {
            get => logosShadowDirection;
            set
            {
                logosShadowDirection = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private double logosBlurRadius { get; set; } = 20;
        public double LogosBlurRadius
        {
            get => logosBlurRadius;
            set
            {
                logosBlurRadius = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private double logosEffectOpacity { get; set; } = 0.75;
        public double LogosEffectOpacity
        {
            get => logosEffectOpacity;
            set
            {
                logosEffectOpacity = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private HorizontalAlignment logoHorizontalAlignment { get; set; } = HorizontalAlignment.Center;
        public HorizontalAlignment LogoHorizontalAlignment
        {
            get => logoHorizontalAlignment;
            set
            {
                logoHorizontalAlignment = value;
                OnPropertyChanged();
            }
        }
        [DontSerialize]
        private VerticalAlignment logoVerticalAlignment { get; set; } = VerticalAlignment.Center;
        public VerticalAlignment LogoVerticalAlignment
        {
            get => logoVerticalAlignment;
            set
            {
                logoVerticalAlignment = value;
                OnPropertyChanged();
            }
        }

        // Playnite serializes settings object to a JSON object and saves it as text file.
        // If you want to exclude some property from being saved then use `JsonDontSerialize` ignore attribute.
        [DontSerialize]
        private bool isLogoAvailable { get; set; } = false;
        [DontSerialize]
        public bool IsLogoAvailable
        {
            get => isLogoAvailable;
            set
            {
                isLogoAvailable = value;
                OnPropertyChanged();
            }
        }
        [DontSerialize]
        private bool isTrailerAvailable { get; set; } = false;
        [DontSerialize]
        public bool IsTrailerAvailable
        {
            get => isTrailerAvailable;
            set
            {
                isTrailerAvailable = value;
                OnPropertyChanged();
            }
        }
        [DontSerialize]
        private bool isMicrotrailerAvailable { get; set; } = false;
        [DontSerialize]
        public bool IsMicrotrailerAvailable
        {
            get => isMicrotrailerAvailable;
            set
            {
                isMicrotrailerAvailable = value;
                OnPropertyChanged();
            }
        }
        [DontSerialize]
        private bool isAnyVideoAvailable { get; set; } = false;
        [DontSerialize]
        public bool IsAnyVideoAvailable
        {
            get => isAnyVideoAvailable;
            set
            {
                isAnyVideoAvailable = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool newContextVideoAvailable { get; set; } = false;
        [DontSerialize]
        public bool NewContextVideoAvailable
        {
            get => newContextVideoAvailable;
            set
            {
                newContextVideoAvailable = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool isVideoPlaying { get; set; } = false;
        [DontSerialize]
        public bool IsVideoPlaying
        {
            get => isVideoPlaying;
            set
            {
                isVideoPlaying = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private string sgdbApiKey = string.Empty;
        public string SgdbApiKey
        {
            get => sgdbApiKey;
            set
            {
                sgdbApiKey = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool downloadLogosOnLibUpdate = true;
        public bool DownloadLogosOnLibUpdate
        {
            get => downloadLogosOnLibUpdate;
            set
            {
                downloadLogosOnLibUpdate = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool libUpdateSelectLogosAutomatically = false;
        public bool LibUpdateSelectLogosAutomatically
        {
            get => libUpdateSelectLogosAutomatically;
            set
            {
                libUpdateSelectLogosAutomatically = value;
                OnPropertyChanged();
            }
        }

        public DateTime LastAutoLibUpdateAssetsDownload = DateTime.Now;

        [DontSerialize]
        private bool processLogosOnDownload = true;
        public bool ProcessLogosOnDownload
        {
            get => processLogosOnDownload;
            set
            {
                processLogosOnDownload = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool logoTrimOnDownload = true;
        public bool LogoTrimOnDownload
        {
            get => logoTrimOnDownload;
            set
            {
                logoTrimOnDownload = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private bool setLogoMaxProcessDimensions = true;
        public bool SetLogoMaxProcessDimensions
        {
            get => setLogoMaxProcessDimensions;
            set
            {
                setLogoMaxProcessDimensions = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private int maxLogoProcessWidth { get; set; } = 640;
        public int MaxLogoProcessWidth
        {
            get => maxLogoProcessWidth;
            set
            {
                maxLogoProcessWidth = value;
                OnPropertyChanged();
            }
        }

        [DontSerialize]
        private int maxLogoProcessHeight { get; set; } = 640;
        public int MaxLogoProcessHeight
        {
            get => maxLogoProcessHeight;
            set
            {
                maxLogoProcessHeight = value;
                OnPropertyChanged();
            }
        }
    }

    public class ExtraMetadataLoaderSettingsViewModel : ObservableObject, ISettings
    {
        private readonly ExtraMetadataLoader plugin;
        private ExtraMetadataLoaderSettings editingClone { get; set; }

        private ExtraMetadataLoaderSettings settings;
        public ExtraMetadataLoaderSettings Settings
        {
            get => settings;
            set
            {
                settings = value;
                OnPropertyChanged();
            }
        }

        public ExtraMetadataLoaderSettingsViewModel(ExtraMetadataLoader plugin)
        {
            // Injecting your plugin instance is required for Save/Load method because Playnite saves data to a location based on what plugin requested the operation.
            this.plugin = plugin;

            // Load saved settings.
            var savedSettings = plugin.LoadPluginSettings<ExtraMetadataLoaderSettings>();

            // LoadPluginSettings returns null if not saved data is available.
            if (savedSettings != null)
            {
                Settings = savedSettings;
            }
            else
            {
                Settings = new ExtraMetadataLoaderSettings();
            }
        }

        public void BeginEdit()
        {
            // Code executed when settings view is opened and user starts editing values.
            editingClone = Serialization.GetClone(Settings);
        }

        public void CancelEdit()
        {
            // Code executed when user decides to cancel any changes made since BeginEdit was called.
            // This method should revert any changes made to Option1 and Option2.
            Settings = editingClone;
        }

        public void EndEdit()
        {
            // Code executed when user decides to confirm changes made since BeginEdit was called.
            // This method should save settings made to Option1 and Option2.
            plugin.SavePluginSettings(Settings);
        }

        public bool VerifySettings(out List<string> errors)
        {
            // Code execute when user decides to confirm changes made since BeginEdit was called.
            // Executed before EndEdit is called and EndEdit is not called if false is returned.
            // List of errors is presented to user if verification fails.
            errors = new List<string>();
            return true;
        }

        public RelayCommand<object> OpenSgdbApiSiteCommand
        {
            get => new RelayCommand<object>((a) =>
            {
                OpenSgdbApiSite();
            });
        }

        private void OpenSgdbApiSite()
        {
            System.Diagnostics.Process.Start(@"https://www.steamgriddb.com/profile/preferences/api");
        }
    }
}