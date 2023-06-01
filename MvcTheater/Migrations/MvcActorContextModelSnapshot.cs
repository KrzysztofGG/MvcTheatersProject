﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcActor.Data;

#nullable disable

namespace MvcTheater.Migrations
{
    [DbContext(typeof(MvcActorContext))]
    partial class MvcActorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MvcTheater.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FavoriteMovie")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("MvcTheater.Models.Opinion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPositive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OpinionText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ShowId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.ToTable("Opinion");
                });

            modelBuilder.Entity("MvcTheater.Models.Show", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ShowDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShowName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ShowPrice")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ShowTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShowType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Show");
                });

            modelBuilder.Entity("MvcTheater.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeamSize")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("MvcTheater.Models.Actor", b =>
                {
                    b.HasOne("MvcTheater.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("MvcTheater.Models.Opinion", b =>
                {
                    b.HasOne("MvcTheater.Models.Show", "Show")
                        .WithMany()
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");
                });

            modelBuilder.Entity("MvcTheater.Models.Show", b =>
                {
                    b.HasOne("MvcTheater.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
