﻿// <auto-generated />
using System;
using System.Collections.Generic;
using EfDemo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfDemo.Infrastructure.SqlServer.Migrations
{
    [DbContext(typeof(EfDemoDbContext))]
    partial class EfDemoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EfDemo.Domain.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nicknames")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("EfDemo.Domain.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<decimal>("BasePrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("PublishDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("EfDemo.Domain.Entities.Cover", b =>
                {
                    b.Property<int>("CoverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoverId"));

                    b.Property<string>("CoverColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ComplexProperty<Dictionary<string, object>>("Dimensions", "EfDemo.Domain.Entities.Cover.Dimensions#Dimensions", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int?>("Height")
                                .HasColumnType("int");

                            b1.Property<int?>("Width")
                                .HasColumnType("int");
                        });

                    b.HasKey("CoverId");

                    b.ToTable("Covers", (string)null);
                });

            modelBuilder.Entity("EfDemo.Domain.Entities.Author", b =>
                {
                    b.OwnsOne("EfDemo.Domain.Entities.ContactDetails", "ContactDetails", b1 =>
                        {
                            b1.Property<int>("AuthorId")
                                .HasColumnType("int");

                            b1.Property<string>("EmailAddress")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Phone")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AuthorId");

                            b1.ToTable("Authors");

                            b1.ToJson("ContactDetails");

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.Navigation("ContactDetails");
                });

            modelBuilder.Entity("EfDemo.Domain.Entities.Book", b =>
                {
                    b.HasOne("EfDemo.Domain.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("EfDemo.Domain.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
