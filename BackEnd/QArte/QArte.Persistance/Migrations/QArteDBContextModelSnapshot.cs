﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QArte.Persistance;

#nullable disable

namespace QArte.Persistance.Migrations
{
    [DbContext(typeof(QArteDBContext))]
    partial class QArteDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.BankAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("BeneficiaryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IBAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PaymentMethodID")
                        .HasColumnType("int");

                    b.Property<string>("StripeInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IBAN")
                        .IsUnique();

                    b.HasIndex(new[] { "PaymentMethodID" }, "IX_BankAccount_PaymentMethodID");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Fee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ExchangeRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("InvoiceID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InvoiceID");

                    b.ToTable("Fees");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Gallery", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.HasKey("ID");

                    b.ToTable("Galleries");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Invoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("BankAccountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SettlementCycleID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("SettlementCycleID")
                        .IsUnique();

                    b.HasIndex(new[] { "BankAccountID" }, "IX_Invoice_BankAccountID");

                    b.HasIndex(new[] { "SettlementCycleID" }, "IX_Invoice_SettlementCycleID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Page", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GalleryID")
                        .HasColumnType("int");

                    b.Property<string>("QRLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GalleryID")
                        .IsUnique();

                    b.HasIndex("QRLink")
                        .IsUnique();

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.HasIndex(new[] { "GalleryID" }, "IX_Page_GalleryID");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.PaymentMethod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("PaymentMethods")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Picture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("GalleryID")
                        .HasColumnType("int");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "GalleryID" }, "IX_Picture_GalleryID");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ERole")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.SettlementCycle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DatePeriod")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("SettlementCycles");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("BankAccountID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("isBanned")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("BankAccountID")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.HasIndex(new[] { "BankAccountID" }, "IX_Artist_BankAccountID");

                    b.HasIndex(new[] { "RoleID" }, "IX_Artist_RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.BankAccount", b =>
                {
                    b.HasOne("QArte.Persistance.PersistanceModels.PaymentMethod", "PaymentMethod")
                        .WithMany("BankAccounts")
                        .HasForeignKey("PaymentMethodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Fee", b =>
                {
                    b.HasOne("QArte.Persistance.PersistanceModels.Invoice", null)
                        .WithMany("Fees")
                        .HasForeignKey("InvoiceID");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Invoice", b =>
                {
                    b.HasOne("QArte.Persistance.PersistanceModels.BankAccount", "BankAccount")
                        .WithMany("Invoices")
                        .HasForeignKey("BankAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QArte.Persistance.PersistanceModels.SettlementCycle", "SettlementCycle")
                        .WithOne()
                        .HasForeignKey("QArte.Persistance.PersistanceModels.Invoice", "SettlementCycleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAccount");

                    b.Navigation("SettlementCycle");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Page", b =>
                {
                    b.HasOne("QArte.Persistance.PersistanceModels.Gallery", "Gallery")
                        .WithOne()
                        .HasForeignKey("QArte.Persistance.PersistanceModels.Page", "GalleryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QArte.Persistance.PersistanceModels.User", "User")
                        .WithOne()
                        .HasForeignKey("QArte.Persistance.PersistanceModels.Page", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gallery");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Picture", b =>
                {
                    b.HasOne("QArte.Persistance.PersistanceModels.Gallery", "Gallery")
                        .WithMany("Pictures")
                        .HasForeignKey("GalleryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gallery");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.User", b =>
                {
                    b.HasOne("QArte.Persistance.PersistanceModels.BankAccount", "BankAccount")
                        .WithOne()
                        .HasForeignKey("QArte.Persistance.PersistanceModels.User", "BankAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QArte.Persistance.PersistanceModels.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BankAccount");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.BankAccount", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Gallery", b =>
                {
                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Invoice", b =>
                {
                    b.Navigation("Fees");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.PaymentMethod", b =>
                {
                    b.Navigation("BankAccounts");
                });

            modelBuilder.Entity("QArte.Persistance.PersistanceModels.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
