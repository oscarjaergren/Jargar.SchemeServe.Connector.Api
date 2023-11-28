﻿// <auto-generated />
using System;
using Jargar.SchemeServe.Connector.Api.Apis.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jargar.SchemeServe.Connector.Api.Migrations
{
    [DbContext(typeof(ProviderDbContext))]
    partial class ProviderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Jargar.SchemeServe.Connector.Api.DataContract.Provider", b =>
                {
                    b.Property<string>("ProviderId")
                        .HasColumnType("TEXT");

                    b.Property<string>("BrandId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CacheExpiration")
                        .HasColumnType("TEXT");

                    b.Property<string>("CharityNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CompaniesHouseNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Constituency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InspectionDirectorate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocalAuthority")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationIds")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MainPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("OnspdLatitude")
                        .HasColumnType("REAL");

                    b.Property<double>("OnspdLongitude")
                        .HasColumnType("REAL");

                    b.Property<string>("OrganisationType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnershipType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalAddressCounty")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalAddressLine1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalAddressLine2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalAddressTownCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistrationStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Uprn")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProviderId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Jargar.SchemeServe.Connector.Api.DataContract.Provider", b =>
                {
                    b.OwnsOne("Jargar.SchemeServe.Connector.Api.DataContract.LastInspection", "LastInspection", b1 =>
                        {
                            b1.Property<string>("ProviderId")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("TEXT");

                            b1.HasKey("ProviderId");

                            b1.ToTable("LastInspections");

                            b1.WithOwner()
                                .HasForeignKey("ProviderId");
                        });

                    b.Navigation("LastInspection")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}