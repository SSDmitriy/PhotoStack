﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PhotoStack.Persistence;

#nullable disable

namespace PhotoStack.Persistence.Migrations
{
    [DbContext(typeof(PhotoStackContext))]
    [Migration("20240210141531_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PhotoStack.Persistence.Entities.ImageEntity", b =>
                {
                    b.Property<Guid>("PhotoCardId")
                        .HasColumnType("uuid");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PhotoCardId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("PhotoStack.Persistence.Entities.PhotoCardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0.1m);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("PhotoCards");
                });

            modelBuilder.Entity("PhotoStack.Persistence.Entities.ImageEntity", b =>
                {
                    b.HasOne("PhotoStack.Persistence.Entities.PhotoCardEntity", "PhotoCard")
                        .WithOne("Image")
                        .HasForeignKey("PhotoStack.Persistence.Entities.ImageEntity", "PhotoCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhotoCard");
                });

            modelBuilder.Entity("PhotoStack.Persistence.Entities.PhotoCardEntity", b =>
                {
                    b.Navigation("Image");
                });
#pragma warning restore 612, 618
        }
    }
}
