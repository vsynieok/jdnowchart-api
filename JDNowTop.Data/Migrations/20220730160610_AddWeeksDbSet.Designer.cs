﻿// <auto-generated />
using System;
using JDNowTop.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JDNowTop.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220730160610_AddWeeksDbSet")]
    partial class AddWeeksDbSet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JDNowTop.Data.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Pos")
                        .HasColumnType("int");

                    b.Property<string>("SongMapName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("WeekId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SongMapName");

                    b.HasIndex("WeekId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("JDNowTop.Data.Models.Song", b =>
                {
                    b.Property<string>("MapName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GameVersion")
                        .HasColumnType("int");

                    b.Property<int>("Mode")
                        .HasColumnType("int");

                    b.HasKey("MapName");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("JDNowTop.Data.Models.Week", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Week");
                });

            modelBuilder.Entity("JDNowTop.Data.Models.Position", b =>
                {
                    b.HasOne("JDNowTop.Data.Models.Song", "Song")
                        .WithMany("Positions")
                        .HasForeignKey("SongMapName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JDNowTop.Data.Models.Week", "Week")
                        .WithMany("Positions")
                        .HasForeignKey("WeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Song");

                    b.Navigation("Week");
                });

            modelBuilder.Entity("JDNowTop.Data.Models.Song", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("JDNowTop.Data.Models.Week", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
