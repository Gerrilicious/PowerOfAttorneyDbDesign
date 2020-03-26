﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PowerOfAttorneyDbDesign;

namespace PowerOfAttorneyDbDesign.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200326083231_UpdatedFinancialInstrumentsAndCompanyRelation")]
    partial class UpdatedFinancialInstrumentsAndCompanyRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.BillingAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("BillingAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BillingAddressId")
                        .IsUnique()
                        .HasFilter("[BillingAddressId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("BillingAddress");
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid>("BillingAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Lei")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.DisclosureRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FinancialInstrumentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FinancialInstrumentId");

                    b.ToTable("DisclosureRequest");
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.DisclosureResponse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DisclosureRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DisclosureRequestId");

                    b.ToTable("DisclosureResponse");
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.FinancialInstrument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("FinancialInstrument");
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.PowerOfAttorney", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FinancialInstrumentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FinancialInstrumentId");

                    b.ToTable("PowerOfAttorney");
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.UserCompanies", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("UserCompanies");
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.BillingAddress", b =>
                {
                    b.HasOne("PowerOfAttorneyDbDesign.Models.Company", "Company")
                        .WithOne("BillingAddress")
                        .HasForeignKey("PowerOfAttorneyDbDesign.Models.BillingAddress", "BillingAddressId");

                    b.HasOne("PowerOfAttorneyDbDesign.Models.User", "User")
                        .WithMany("BillingAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.DisclosureRequest", b =>
                {
                    b.HasOne("PowerOfAttorneyDbDesign.Models.Company", "Company")
                        .WithMany("DisclosureRequests")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PowerOfAttorneyDbDesign.Models.FinancialInstrument", "FinancialInstrument")
                        .WithMany("DisclosureRequests")
                        .HasForeignKey("FinancialInstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.DisclosureResponse", b =>
                {
                    b.HasOne("PowerOfAttorneyDbDesign.Models.Company", "Company")
                        .WithMany("DisclosureResponses")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PowerOfAttorneyDbDesign.Models.DisclosureRequest", "DisclosureRequest")
                        .WithMany("DisclosureResponses")
                        .HasForeignKey("DisclosureRequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.FinancialInstrument", b =>
                {
                    b.HasOne("PowerOfAttorneyDbDesign.Models.Company", "Company")
                        .WithMany("FinancialInstruments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.PowerOfAttorney", b =>
                {
                    b.HasOne("PowerOfAttorneyDbDesign.Models.Company", "Company")
                        .WithMany("PowerOfAttorneys")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PowerOfAttorneyDbDesign.Models.FinancialInstrument", "FinancialInstrument")
                        .WithMany("PowerOfAttorneys")
                        .HasForeignKey("FinancialInstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PowerOfAttorneyDbDesign.Models.UserCompanies", b =>
                {
                    b.HasOne("PowerOfAttorneyDbDesign.Models.Company", "Company")
                        .WithMany("UserCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PowerOfAttorneyDbDesign.Models.User", "User")
                        .WithMany("UserCompanies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
