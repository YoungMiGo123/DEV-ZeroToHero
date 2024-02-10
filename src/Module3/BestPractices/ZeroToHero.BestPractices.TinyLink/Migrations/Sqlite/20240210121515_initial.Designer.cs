﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZeroToHero.BestPractices.TinyLink.Infrastructure;

#nullable disable

namespace ZeroToHero.BestPractices.TinyLink.Migrations.Sqlite
{
    [DbContext(typeof(TinyLinkDatabase))]
    [Migration("20240210121515_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("ZeroToHero.BestPractices.TinyLink.Models.Entities.Link", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deactivated")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortenedUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TinyLinks");
                });

            modelBuilder.Entity("ZeroToHero.BestPractices.TinyLink.Models.Entities.Visit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deactivated")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Device")
                        .HasColumnType("TEXT");

                    b.Property<string>("IPAddress")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LinkId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LinkId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("ZeroToHero.BestPractices.TinyLink.Models.Entities.Visit", b =>
                {
                    b.HasOne("ZeroToHero.BestPractices.TinyLink.Models.Entities.Link", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Link");
                });
#pragma warning restore 612, 618
        }
    }
}
