﻿// <auto-generated />
using System;
using Klinika.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Klinika.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Klinika.Database.Ljekar", b =>
                {
                    b.Property<int>("LjekarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LjekarId"));

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LjekarId");

                    b.ToTable("Ljekar");
                });

            modelBuilder.Entity("Klinika.Database.Nalaz", b =>
                {
                    b.Property<int>("NalazId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NalazId"));

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrijemId")
                        .HasColumnType("int");

                    b.HasKey("NalazId");

                    b.HasIndex("PrijemId");

                    b.ToTable("Nalaz");
                });

            modelBuilder.Entity("Klinika.Database.Pacijent", b =>
                {
                    b.Property<int>("PacijentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacijentId"));

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImePrezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PacijentId");

                    b.ToTable("Pacijent");
                });

            modelBuilder.Entity("Klinika.Database.Prijem", b =>
                {
                    b.Property<int>("PrijemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrijemId"));

                    b.Property<DateTime>("DatumPrijema")
                        .HasColumnType("datetime2");

                    b.Property<string>("HitniPrijem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LjekarId")
                        .HasColumnType("int");

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.HasKey("PrijemId");

                    b.HasIndex("LjekarId");

                    b.HasIndex("PacijentId");

                    b.ToTable("Prijem");
                });

            modelBuilder.Entity("Klinika.Database.Nalaz", b =>
                {
                    b.HasOne("Klinika.Database.Prijem", "Prijem")
                        .WithMany()
                        .HasForeignKey("PrijemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prijem");
                });

            modelBuilder.Entity("Klinika.Database.Prijem", b =>
                {
                    b.HasOne("Klinika.Database.Ljekar", "Ljekar")
                        .WithMany()
                        .HasForeignKey("LjekarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Klinika.Database.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ljekar");

                    b.Navigation("Pacijent");
                });
#pragma warning restore 612, 618
        }
    }
}
