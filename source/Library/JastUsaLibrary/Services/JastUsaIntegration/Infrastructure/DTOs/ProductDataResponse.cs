using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Playnite.SDK.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JastUsaLibrary.Services.JastUsaIntegration.Infrastructure.DTOs
{
    public class ProductResponse
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("productESRB")]
        public object ProductEsrb { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("releaseDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("originalReleaseDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? OriginalReleaseDate { get; set; }

        [JsonProperty("publishers")]
        public Publisher[] Publishers { get; set; }

        [JsonProperty("studios")]
        public Publisher[] Studios { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("demoProductLink")]
        public object DemoProductLink { get; set; }

        [JsonProperty("matureContentFlag")]
        public bool MatureContentFlag { get; set; }

        [JsonProperty("productTaxons")]
        public ProductTaxon[] ProductTaxons { get; set; }

        [JsonProperty("mainTaxon")]
        public object MainTaxon { get; set; }

        [JsonProperty("reviews")]
        public Review[] Reviews { get; set; }

        [JsonProperty("averageRating")]
        public double AverageRating { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("id")]
        public long JastproductresponseId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("attributes")]
        public Attribute[] Attributes { get; set; }

        [JsonProperty("variants")]
        public ProductResponseVariant[] Variants { get; set; }

        [JsonProperty("options")]
        public object[] Options { get; set; }

        [JsonProperty("associations")]
        public object[] Associations { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("translations")]
        public JastproductresponseTranslations Translations { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("defaultVariant")]
        public string DefaultVariant { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("originalPrice")]
        public long OriginalPrice { get; set; }

        [JsonProperty("discount")]
        public double Discount { get; set; }

        [JsonProperty("isFree")]
        public bool IsFree { get; set; }

        [JsonProperty("promotionEndsAt")]
        public DateTimeOffset? PromotionEndsAt { get; set; }

        [JsonProperty("canonicalProductId")]
        public object CanonicalProductId { get; set; }

        [JsonProperty("bundlePricingMode")]
        public string BundlePricingMode { get; set; }

        [JsonProperty("canonicalProduct")]
        public object CanonicalProduct { get; set; }

        [JsonProperty("additionalContent")]
        public object[] AdditionalContent { get; set; }

        [JsonProperty("grantedProducts")]
        public GrantedProduct[] GrantedProducts { get; set; }

        [JsonProperty("reviewCount")]
        public long ReviewCount { get; set; }

        [JsonProperty("topReviews")]
        public TopReview[] TopReviews { get; set; }

        [JsonProperty("bundles")]
        public object[] Bundles { get; set; }

        [JsonProperty("bonusPoints")]
        public BonusPoints BonusPoints { get; set; }

        //[SerializationPropertyName("@context")]
        //public string Context { get; set; }

        //[SerializationPropertyName("@id")]
        //public string Id { get; set; }

        //[SerializationPropertyName("@type")]
        //public string Type { get; set; }

        //[SerializationPropertyName("productESRB")]
        //public ProductEsrb ProductEsrb { get; set; }

        //[SerializationPropertyName("sku")]
        //public string Sku { get; set; }

        //[SerializationPropertyName("releaseDate")]
        //public DateTime ReleaseDate { get; set; }

        //[SerializationPropertyName("originalReleaseDate")]
        //public DateTime? OriginalReleaseDate { get; set; }

        //[SerializationPropertyName("productTaxons")]
        //public string[] ProductTaxons { get; set; }

        //[SerializationPropertyName("mainTaxon")]
        //public string MainTaxon { get; set; }

        //[SerializationPropertyName("reviews")]
        //public object[] Reviews { get; set; }

        //[SerializationPropertyName("averageRating")]
        //public double AverageRating { get; set; }

        //[SerializationPropertyName("images")]
        //public List<Image> Images { get; set; }

        //[SerializationPropertyName("id")]
        //public int ProductResponseId { get; set; }

        //[SerializationPropertyName("code")]
        //public string Code { get; set; }

        //[SerializationPropertyName("attributes")]
        //public ProductResponseAttribute[] Attributes { get; set; }

        //[SerializationPropertyName("variants")]
        //public ProductResponseVariant[] Variants { get; set; }

        //[SerializationPropertyName("options")]
        //public object[] Options { get; set; }

        //[SerializationPropertyName("associations")]
        //public object[] Associations { get; set; }

        //[SerializationPropertyName("createdAt")]
        //public DateTimeOffset CreatedAt { get; set; }

        //[SerializationPropertyName("updatedAt")]
        //public DateTimeOffset UpdatedAt { get; set; }

        //[SerializationPropertyName("translations")]
        //public Dictionary<string, ProductResponseTranslationData> Translations { get; set; }

        //[SerializationPropertyName("shortDescription")]
        //public string ShortDescription { get; set; }

        //[SerializationPropertyName("name")]
        //public string Name { get; set; }

        //[SerializationPropertyName("description")]
        //public string Description { get; set; }
        //[SerializationPropertyName("slug")]
        //public string Slug { get; set; }

        //[SerializationPropertyName("defaultVariant")]
        //public string DefaultVariant { get; set; }

        //[SerializationPropertyName("bonusPoints")]
        //public BonusPoints BonusPoints { get; set; }
    }

    public class Attribute
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("localeCode")]
        public string LocaleCode { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public string AttributeType { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("attribute_id")]
        public long AttributeId { get; set; }

        [JsonProperty("configuration")]
        public object[] Configuration { get; set; }
    }

    public class BonusPoints
    {
        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
    }

    public class GrantedProduct
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Image
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public ImageType Type { get; set; }

        [JsonProperty("priority")]
        public int? Priority { get; set; }

        [JsonProperty("matureContent")]
        public bool MatureContent { get; set; }

        [JsonProperty("id")]
        public long ImageId { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(TypeEnumConverter))]
        public TypeEnum ImageType { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("imagePlaceholder")]
        public ImagePlaceholder ImagePlaceholder { get; set; }
    }

    public class ImagePlaceholder
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("blurredHash")]
        public string BlurredHash { get; set; }

        [JsonProperty("estimatedColor")]
        public string EstimatedColor { get; set; }
    }

    public class ProductTaxon
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("taxon")]
        public Taxon Taxon { get; set; }
    }

    public class Taxon
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Publisher
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public int PublisherId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("color")]
        public object Color { get; set; }

        [JsonProperty("image")]
        public object Image { get; set; }
    }

    public class Review
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        [JsonConverter(typeof(ReviewTypeConverter))]
        public ReviewType Type { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public class TopReview
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }

    public partial class JastproductresponseTranslations
    {
        [JsonProperty("en_US")]
        public PurpleEnUs EnUs { get; set; }
    }

    public partial class PurpleEnUs
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("id")]
        public long EnUsId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class ProductResponseVariant
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("promotionEndsAt")]
        public DateTimeOffset? PromotionEndsAt { get; set; }

        [JsonProperty("channelPricings")]
        public ChannelPricings ChannelPricings { get; set; }

        [JsonProperty("id")]
        public long VariantId { get; set; }

        [JsonProperty("translations")]
        public VariantTranslations Translations { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("originalPrice")]
        public long OriginalPrice { get; set; }

        [JsonProperty("discount")]
        public double Discount { get; set; }

        [JsonProperty("isFree")]
        public bool IsFree { get; set; }
    }

    public partial class ChannelPricings
    {
        [JsonProperty("JASTUSA")]
        public Jastusa Jastusa { get; set; }
    }

    public partial class Jastusa
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("channelCode")]
        public string ChannelCode { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("originalPrice")]
        public object OriginalPrice { get; set; }
    }

    public partial class VariantTranslations
    {
        [JsonProperty("en_US")]
        public FluffyEnUs EnUs { get; set; }
    }

    public partial class FluffyEnUs
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long EnUsId { get; set; }

        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }
    }

    public enum TypeEnum
    {
        Empty,
        ProductLibraryCapsule,
        ProductMainCapsule,
        ProductVerticalCapsule,
        ProductBackground,
        TailPackageThumbnailHomepage,
        WideBannerThumbnailCatalog
    };

    public enum ImageType { ProductImage };

    public enum ReviewType { ProductReview };


    internal class ImageTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ImageType) || t == typeof(ImageType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "ProductImage")
            {
                return ImageType.ProductImage;
            }
            throw new Exception("Cannot unmarshal type ImageType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ImageType)untypedValue;
            if (value == ImageType.ProductImage)
            {
                serializer.Serialize(writer, "ProductImage");
                return;
            }
            throw new Exception("Cannot marshal type ImageType");
        }

        public static readonly ImageTypeConverter Singleton = new ImageTypeConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return TypeEnum.Empty;
                case "PRODUCT_LIBRARY_CAPSULE":
                    return TypeEnum.ProductLibraryCapsule;
                case "PRODUCT_MAIN_CAPSULE":
                    return TypeEnum.ProductMainCapsule;
                case "PRODUCT_VERTICAL_CAPSULE":
                    return TypeEnum.ProductVerticalCapsule;
                case "PRODUCT_BACKGROUND":
                    return TypeEnum.ProductBackground;
                case "TAIL_PACKAGE_THUMBNAIL_HOMEPAGE":
                    return TypeEnum.TailPackageThumbnailHomepage;
                case "WIDE_BANNER_THUMBNAIL_CATALOG":
                    return TypeEnum.WideBannerThumbnailCatalog;
            }

            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case TypeEnum.ProductLibraryCapsule:
                    serializer.Serialize(writer, "PRODUCT_LIBRARY_CAPSULE");
                    return;
                case TypeEnum.ProductMainCapsule:
                    serializer.Serialize(writer, "PRODUCT_MAIN_CAPSULE");
                    return;
                case TypeEnum.ProductVerticalCapsule:
                    serializer.Serialize(writer, "PRODUCT_VERTICAL_CAPSULE");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class ReviewTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ReviewType) || t == typeof(ReviewType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "ProductReview")
            {
                return ReviewType.ProductReview;
            }
            throw new Exception("Cannot unmarshal type ReviewType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ReviewType)untypedValue;
            if (value == ReviewType.ProductReview)
            {
                serializer.Serialize(writer, "ProductReview");
                return;
            }
            throw new Exception("Cannot marshal type ReviewType");
        }

        public static readonly ReviewTypeConverter Singleton = new ReviewTypeConverter();
    }

    public class DateTimeConverter : JsonConverter
    {
        private const string Format = "yyyy-MM-dd HH:mm:ss";

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value is null)
                return objectType == typeof(DateTime?) ? (DateTime?)null : default(DateTime);

            return DateTime.ParseExact(
                (string)reader.Value,
                Format,
                CultureInfo.InvariantCulture);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteValue(((DateTime)value).ToString(Format));
        }
    }


}