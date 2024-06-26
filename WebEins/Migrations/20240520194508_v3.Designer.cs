﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebEins.Migrations
{
    [DbContext(typeof(WEContext))]
    [Migration("20240520194508_v3")]
    partial class v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebEins.Models.Bestellung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KündeId")
                        .HasColumnType("int");

                    b.Property<double>("Menge")
                        .HasColumnType("float");

                    b.Property<int>("ProdukteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KündeId");

                    b.HasIndex("ProdukteId");

                    b.ToTable("Bestellung");
                });

            modelBuilder.Entity("WebEins.Models.Künde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Addresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ausweisidentificactionsnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Personalnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Künde");
                });

            modelBuilder.Entity("WebEins.Models.Produkte", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Betrag")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preis")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Produkte");
                });

            modelBuilder.Entity("WebEins.Models.Bestellung", b =>
                {
                    b.HasOne("WebEins.Models.Künde", "Künde")
                        .WithMany("Bestellungen")
                        .HasForeignKey("KündeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebEins.Models.Produkte", "Produkte")
                        .WithMany("Bestellungen")
                        .HasForeignKey("ProdukteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Künde");

                    b.Navigation("Produkte");
                });

            modelBuilder.Entity("WebEins.Models.Künde", b =>
                {
                    b.Navigation("Bestellungen");
                });

            modelBuilder.Entity("WebEins.Models.Produkte", b =>
                {
                    b.Navigation("Bestellungen");
                });
#pragma warning restore 612, 618
        }
    }
}
