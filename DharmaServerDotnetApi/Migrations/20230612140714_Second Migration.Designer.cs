﻿// <auto-generated />
using System;
using DharmaServerDotnetApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DharmaServerDotnetApi.Migrations
{
    [DbContext(typeof(DharmaDbContext))]
    [Migration("20230612140714_Second Migration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DharmaServerDotnetApi.Models.AuthorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.BookModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("LibraryModelId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("LibraryModelId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.LibraryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Library");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LibraryModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibraryModelId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.BookModel", b =>
                {
                    b.HasOne("DharmaServerDotnetApi.Models.AuthorModel", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DharmaServerDotnetApi.Models.LibraryModel", null)
                        .WithMany("Books")
                        .HasForeignKey("LibraryModelId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.UserModel", b =>
                {
                    b.HasOne("DharmaServerDotnetApi.Models.LibraryModel", null)
                        .WithMany("Members")
                        .HasForeignKey("LibraryModelId");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.AuthorModel", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.LibraryModel", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
