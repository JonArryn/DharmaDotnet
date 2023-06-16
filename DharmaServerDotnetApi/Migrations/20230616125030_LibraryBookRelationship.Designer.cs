﻿// <auto-generated />
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
    [Migration("20230616125030_LibraryBookRelationship")]
    partial class LibraryBookRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DharmaServerDotnetApi.Models.Author", b =>
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PenName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.Library", b =>
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

            modelBuilder.Entity("DharmaServerDotnetApi.Models.LibraryBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("LibraryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("LibraryId");

                    b.ToTable("LibraryBook");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.User", b =>
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

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.Book", b =>
                {
                    b.HasOne("DharmaServerDotnetApi.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.LibraryBook", b =>
                {
                    b.HasOne("DharmaServerDotnetApi.Models.Book", "Book")
                        .WithMany("LibraryBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DharmaServerDotnetApi.Models.Library", "Library")
                        .WithMany("LibraryBooks")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.Book", b =>
                {
                    b.Navigation("LibraryBooks");
                });

            modelBuilder.Entity("DharmaServerDotnetApi.Models.Library", b =>
                {
                    b.Navigation("LibraryBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
