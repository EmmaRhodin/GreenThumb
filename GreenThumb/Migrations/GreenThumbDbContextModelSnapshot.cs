﻿// <auto-generated />
using System;
using GreenThumb.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenThumb.Migrations
{
    [DbContext(typeof(GreenThumbDbContext))]
    partial class GreenThumbDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GreenThumb.Models.GardenModel", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("adress");

                    b.Property<int>("GardenId")
                        .HasColumnType("int")
                        .HasColumnName("garden_id");

                    b.HasKey("UserId");

                    b.ToTable("Garden");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Adress = "Stengatan 12, Malmö",
                            GardenId = 1
                        },
                        new
                        {
                            UserId = 2,
                            Adress = "Kärleksgatan 72C, Lund",
                            GardenId = 2
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.InstructionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Instruction")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("instruction");

                    b.Property<int?>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("Instructions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Instruction = "Vattna varannan dag",
                            PlantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Instruction = "Vattna varannan dag",
                            PlantId = 2
                        },
                        new
                        {
                            Id = 3,
                            Instruction = "Vattna varje dag",
                            PlantId = 3
                        },
                        new
                        {
                            Id = 4,
                            Instruction = "Stäng näsan",
                            PlantId = 3
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.PlantModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BotanicalName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("botanical_name");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int?>("GardenModelUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("GardenModelUserId");

                    b.ToTable("Plants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BotanicalName = "Anemone nemorosa",
                            Description = "En blomma som blir 10-20 cm hög, med vita blad",
                            Name = "Vitsippa"
                        },
                        new
                        {
                            Id = 2,
                            BotanicalName = "Helianthus annuus",
                            Description = "En blomma som kan bli 3 m hög, med stora gula blad",
                            Name = "Solros"
                        },
                        new
                        {
                            Id = 3,
                            BotanicalName = "Helicodiceros muscivorus",
                            Description = "En illaluktande planta som sägs likna ändan på ett dött djur",
                            Name = "Fläckig drakkalla"
                        },
                        new
                        {
                            Id = 4,
                            BotanicalName = "Taraxacum sect. Spectabilia",
                            Description = "En liten gul blomma som ofta ses som ogräs",
                            Name = "Maskros"
                        },
                        new
                        {
                            Id = 5,
                            BotanicalName = "Taraxacum sect. Ruderalia",
                            Description = "En liten gul blomma som ofta ses som ogräs",
                            Name = "Maskros"
                        },
                        new
                        {
                            Id = 6,
                            BotanicalName = "Cyanus Segetum",
                            Description = "En blomma som kan bli 70 cm hög med mörkblåa blad",
                            Name = "Blåklint"
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 2,
                            Password = "STEFANÄRBÄST",
                            Username = "Stefan"
                        },
                        new
                        {
                            UserId = 1,
                            Password = "123",
                            Username = "Emma"
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.GardenModel", b =>
                {
                    b.HasOne("GreenThumb.Models.UserModel", "User")
                        .WithOne("Garden")
                        .HasForeignKey("GreenThumb.Models.GardenModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenThumb.Models.InstructionModel", b =>
                {
                    b.HasOne("GreenThumb.Models.PlantModel", "Plant")
                        .WithMany("Instruction")
                        .HasForeignKey("PlantId");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumb.Models.PlantModel", b =>
                {
                    b.HasOne("GreenThumb.Models.GardenModel", null)
                        .WithMany("Plants")
                        .HasForeignKey("GardenModelUserId");
                });

            modelBuilder.Entity("GreenThumb.Models.GardenModel", b =>
                {
                    b.Navigation("Plants");
                });

            modelBuilder.Entity("GreenThumb.Models.PlantModel", b =>
                {
                    b.Navigation("Instruction");
                });

            modelBuilder.Entity("GreenThumb.Models.UserModel", b =>
                {
                    b.Navigation("Garden");
                });
#pragma warning restore 612, 618
        }
    }
}
