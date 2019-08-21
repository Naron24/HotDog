﻿// <auto-generated />
using System;
using HotDog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotDog.Migrations
{
    [DbContext(typeof(HotDogContext))]
    [Migration("20190819205903_HotDog")]
    partial class HotDog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotDog.Models.HotDogViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long>("Price");

                    b.HasKey("Id");

                    b.ToTable("HotDogViewModel");
                });

            modelBuilder.Entity("HotDog.Models.Ingridients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HotDogViewModelId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("HotDogViewModelId");

                    b.ToTable("Ingridients");
                });

            modelBuilder.Entity("HotDog.Models.Ingridients", b =>
                {
                    b.HasOne("HotDog.Models.HotDogViewModel")
                        .WithMany("Ingridients")
                        .HasForeignKey("HotDogViewModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
