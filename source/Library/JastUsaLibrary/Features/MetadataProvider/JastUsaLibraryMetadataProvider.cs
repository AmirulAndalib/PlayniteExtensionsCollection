using Playnite.SDK;
using Playnite.SDK.Data;
using Playnite.SDK.Models;
using PluginsCommon;
using FlowHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JastUsaLibrary.Services.JastUsaIntegration.Infrastructure.DTOs;
using JastUsaLibrary.JastLibraryCacheService.Application;

namespace JastUsaLibrary.Features.MetadataProvider
{
    public class JastUsaLibraryMetadataProvider : LibraryMetadataProvider
    {
        private readonly ILibraryCacheService _libraryCacheService;

        public JastUsaLibraryMetadataProvider(ILibraryCacheService libraryCacheService)
        {
            _libraryCacheService = libraryCacheService;
        }

        public override GameMetadata GetMetadata(Playnite.SDK.Models.Game game)
        {
            var productCode = _libraryCacheService.GetCacheById(Convert.ToInt32(game.GameId))?.JastGameData?.ProductCode;
            if (productCode.IsNullOrEmpty())
            {
                return new GameMetadata();
            }

            var url = string.Format(@"https://app.jaststore.com/api/v2/shop/products/{0}?localeCode=en_US", productCode);
            var downloadedString = HttpRequestFactory.GetHttpRequest()
                .WithUrl(url)
                .DownloadString();
            if (!downloadedString.IsSuccess)
            {
                return new GameMetadata();
            }

            var productResponse = Serialization.FromJson<ProductResponse>(downloadedString.Content);
            var metadata = new GameMetadata()
            {
                Name = GameNameSanitizer.Satinize(productResponse.Name),
                Description = productResponse.Description,
                Platforms = new HashSet<MetadataProperty> { new MetadataSpecProperty("pc_windows") }
            };

            if (productResponse.OriginalReleaseDate.HasValue)
            {
                metadata.ReleaseDate = new ReleaseDate(productResponse.OriginalReleaseDate.Value);
            }

            var developersNames = productResponse.Studios?.Select(x => x.Name).ToList();
            if (developersNames.HasItems())
            {
                metadata.Developers = new HashSet<MetadataProperty>(developersNames.Select(x => new MetadataNameProperty(x)));
            }

            var publishersNames = productResponse.Publishers?.Select(x => x.Name).ToList();
            if (publishersNames.HasItems())
            {
                metadata.Publishers = new HashSet<MetadataProperty>(publishersNames.Select(x => new MetadataNameProperty(x)));
            }

            var coverImage = productResponse.Images
                .FirstOrDefault(x => x.ImageType == TypeEnum.ProductLibraryCapsule);
            if (coverImage != null)
            {
                metadata.CoverImage = new MetadataFile(string.Format(JastUsaWebUrls.JastMediaUrlTemplate, coverImage.Path));
            }

            var backgroundImage = productResponse.Images
                .FirstOrDefault(x => x.ImageType == TypeEnum.ProductBackground)
                               ?? productResponse.Images
                .FirstOrDefault(x => x.ImageType == TypeEnum.Empty);
            if (backgroundImage != null)
            {
                metadata.BackgroundImage = new MetadataFile(string.Format(JastUsaWebUrls.JastMediaUrlTemplate, backgroundImage.Path));
            }

            metadata.Links = new List<Link> { new Link("Store", @"https://jaststore.com/games/" + productResponse.Code) };

            var supportsWindowsPlatform = productResponse.ProductTaxons.Any(x => x.Taxon.Code == "windows");
            var supportsLinuxPlatform = productResponse.ProductTaxons.Any(x => x.Taxon.Code == "linux");
            var supportsMacPlatform = productResponse.ProductTaxons.Any(x => x.Taxon.Code == "mac");

            if (supportsWindowsPlatform)
            {
                metadata.Platforms.Add(new MetadataSpecProperty("pc_windows"));
            }

            if (supportsMacPlatform)
            {
                metadata.Platforms.Add(new MetadataSpecProperty("macintosh"));
            }

            if (supportsLinuxPlatform)
            {
                metadata.Platforms.Add(new MetadataSpecProperty("pc_linux"));
            }

            return metadata;
        }
    }

}