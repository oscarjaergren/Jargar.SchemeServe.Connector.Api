﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Jargar.SchemeServe.Connector.Api.DataContract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#pragma warning disable 219, 612, 618
#nullable disable

namespace MyCompiledModels
{
    internal partial class ProviderEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Jargar.SchemeServe.Connector.Api.DataContract.Provider",
                typeof(Provider),
                baseEntityType);

            var providerId = runtimeEntityType.AddProperty(
                "ProviderId",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("ProviderId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<ProviderId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw);
            providerId.TypeMapping = SqliteStringTypeMapping.Default;

            var brandId = runtimeEntityType.AddProperty(
                "BrandId",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("BrandId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<BrandId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            brandId.TypeMapping = SqliteStringTypeMapping.Default;

            var brandName = runtimeEntityType.AddProperty(
                "BrandName",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("BrandName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<BrandName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            brandName.TypeMapping = SqliteStringTypeMapping.Default;

            var cacheExpiration = runtimeEntityType.AddProperty(
                "CacheExpiration",
                typeof(DateTime),
                propertyInfo: typeof(Provider).GetProperty("CacheExpiration", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<CacheExpiration>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            cacheExpiration.TypeMapping = SqliteDateTimeTypeMapping.Default;

            var charityNumber = runtimeEntityType.AddProperty(
                "CharityNumber",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("CharityNumber", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<CharityNumber>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            charityNumber.TypeMapping = SqliteStringTypeMapping.Default;

            var companiesHouseNumber = runtimeEntityType.AddProperty(
                "CompaniesHouseNumber",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("CompaniesHouseNumber", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<CompaniesHouseNumber>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            companiesHouseNumber.TypeMapping = SqliteStringTypeMapping.Default;

            var constituency = runtimeEntityType.AddProperty(
                "Constituency",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("Constituency", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<Constituency>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            constituency.TypeMapping = SqliteStringTypeMapping.Default;

            var inspectionDirectorate = runtimeEntityType.AddProperty(
                "InspectionDirectorate",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("InspectionDirectorate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<InspectionDirectorate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            inspectionDirectorate.TypeMapping = SqliteStringTypeMapping.Default;

            var localAuthority = runtimeEntityType.AddProperty(
                "LocalAuthority",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("LocalAuthority", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<LocalAuthority>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            localAuthority.TypeMapping = SqliteStringTypeMapping.Default;

            var locationIds = runtimeEntityType.AddProperty(
                "LocationIds",
                typeof(List<string>),
                propertyInfo: typeof(Provider).GetProperty("LocationIds", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<LocationIds>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            locationIds.TypeMapping = SqliteStringTypeMapping.Default.Clone(
                comparer: new ListComparer<string>(new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v)),
                keyComparer: new ListComparer<string>(new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v)),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                converter: new CollectionToJsonStringConverter<string>(new JsonCollectionReaderWriter<List<string>, List<string>, string>(
                    JsonStringReaderWriter.Instance)),
                jsonValueReaderWriter: new JsonCollectionReaderWriter<List<string>, List<string>, string>(
                    JsonStringReaderWriter.Instance),
                elementMapping: SqliteStringTypeMapping.Default);

            var mainPhoneNumber = runtimeEntityType.AddProperty(
                "MainPhoneNumber",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("MainPhoneNumber", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<MainPhoneNumber>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            mainPhoneNumber.TypeMapping = SqliteStringTypeMapping.Default;

            var name = runtimeEntityType.AddProperty(
                "Name",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<Name>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            name.TypeMapping = SqliteStringTypeMapping.Default;

            var onspdLatitude = runtimeEntityType.AddProperty(
                "OnspdLatitude",
                typeof(double),
                propertyInfo: typeof(Provider).GetProperty("OnspdLatitude", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<OnspdLatitude>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0.0);
            onspdLatitude.TypeMapping = DoubleTypeMapping.Default.Clone(
                comparer: new ValueComparer<double>(
                    (double v1, double v2) => v1.Equals(v2),
                    (double v) => v.GetHashCode(),
                    (double v) => v),
                keyComparer: new ValueComparer<double>(
                    (double v1, double v2) => v1.Equals(v2),
                    (double v) => v.GetHashCode(),
                    (double v) => v),
                providerValueComparer: new ValueComparer<double>(
                    (double v1, double v2) => v1.Equals(v2),
                    (double v) => v.GetHashCode(),
                    (double v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "REAL"));

            var onspdLongitude = runtimeEntityType.AddProperty(
                "OnspdLongitude",
                typeof(double),
                propertyInfo: typeof(Provider).GetProperty("OnspdLongitude", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<OnspdLongitude>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0.0);
            onspdLongitude.TypeMapping = DoubleTypeMapping.Default.Clone(
                comparer: new ValueComparer<double>(
                    (double v1, double v2) => v1.Equals(v2),
                    (double v) => v.GetHashCode(),
                    (double v) => v),
                keyComparer: new ValueComparer<double>(
                    (double v1, double v2) => v1.Equals(v2),
                    (double v) => v.GetHashCode(),
                    (double v) => v),
                providerValueComparer: new ValueComparer<double>(
                    (double v1, double v2) => v1.Equals(v2),
                    (double v) => v.GetHashCode(),
                    (double v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "REAL"));

            var organisationType = runtimeEntityType.AddProperty(
                "OrganisationType",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("OrganisationType", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<OrganisationType>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            organisationType.TypeMapping = SqliteStringTypeMapping.Default;

            var ownershipType = runtimeEntityType.AddProperty(
                "OwnershipType",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("OwnershipType", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<OwnershipType>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            ownershipType.TypeMapping = SqliteStringTypeMapping.Default;

            var postalAddressCounty = runtimeEntityType.AddProperty(
                "PostalAddressCounty",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("PostalAddressCounty", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<PostalAddressCounty>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            postalAddressCounty.TypeMapping = SqliteStringTypeMapping.Default;

            var postalAddressLine1 = runtimeEntityType.AddProperty(
                "PostalAddressLine1",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("PostalAddressLine1", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<PostalAddressLine1>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            postalAddressLine1.TypeMapping = SqliteStringTypeMapping.Default;

            var postalAddressLine2 = runtimeEntityType.AddProperty(
                "PostalAddressLine2",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("PostalAddressLine2", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<PostalAddressLine2>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            postalAddressLine2.TypeMapping = SqliteStringTypeMapping.Default;

            var postalAddressTownCity = runtimeEntityType.AddProperty(
                "PostalAddressTownCity",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("PostalAddressTownCity", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<PostalAddressTownCity>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            postalAddressTownCity.TypeMapping = SqliteStringTypeMapping.Default;

            var postalCode = runtimeEntityType.AddProperty(
                "PostalCode",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("PostalCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<PostalCode>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            postalCode.TypeMapping = SqliteStringTypeMapping.Default;

            var region = runtimeEntityType.AddProperty(
                "Region",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("Region", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<Region>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            region.TypeMapping = SqliteStringTypeMapping.Default;

            var registrationDate = runtimeEntityType.AddProperty(
                "RegistrationDate",
                typeof(DateTime),
                propertyInfo: typeof(Provider).GetProperty("RegistrationDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<RegistrationDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            registrationDate.TypeMapping = SqliteDateTimeTypeMapping.Default;

            var registrationStatus = runtimeEntityType.AddProperty(
                "RegistrationStatus",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("RegistrationStatus", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<RegistrationStatus>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            registrationStatus.TypeMapping = SqliteStringTypeMapping.Default;

            var type = runtimeEntityType.AddProperty(
                "Type",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("Type", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<Type>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            type.TypeMapping = SqliteStringTypeMapping.Default;

            var uprn = runtimeEntityType.AddProperty(
                "Uprn",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("Uprn", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<Uprn>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            uprn.TypeMapping = SqliteStringTypeMapping.Default;

            var website = runtimeEntityType.AddProperty(
                "Website",
                typeof(string),
                propertyInfo: typeof(Provider).GetProperty("Website", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Provider).GetField("<Website>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            website.TypeMapping = SqliteStringTypeMapping.Default;

            var key = runtimeEntityType.AddKey(
                new[] { providerId });
            runtimeEntityType.SetPrimaryKey(key);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Providers");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
