﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PBL.Data;

#nullable disable

namespace PBL.Migrations
{
    [DbContext(typeof(PblContext))]
    [Migration("20231116162801_Cria Banco")]
    partial class CriaBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ColisaoModel", b =>
                {
                    b.Property<int>("ColisaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColisaoId"), 1L, 1);

                    b.Property<double?>("AlturaColisao")
                        .HasColumnType("float");

                    b.Property<int>("MeteoroId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetilId")
                        .HasColumnType("int");

                    b.Property<double?>("TempoColisao")
                        .HasColumnType("float");

                    b.Property<double?>("VoParaColidir")
                        .HasColumnType("float");

                    b.HasKey("ColisaoId");

                    b.HasIndex("MeteoroId");

                    b.HasIndex("ProjetilId");

                    b.ToTable("Colisao");
                });

            modelBuilder.Entity("PBL.Models.MeteoroModel", b =>
                {
                    b.Property<int>("MeteoroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeteoroId"), 1L, 1);

                    b.Property<int>("AlturaInicial")
                        .HasColumnType("int");

                    b.Property<int>("DistanciaHorizontal")
                        .HasColumnType("int");

                    b.Property<int>("VelocidadeMeteoro")
                        .HasColumnType("int");

                    b.HasKey("MeteoroId");

                    b.ToTable("Meteoro");
                });

            modelBuilder.Entity("PBL.Models.ProjetilModel", b =>
                {
                    b.Property<int>("ProjetilId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjetilId"), 1L, 1);

                    b.Property<double>("AnguloGraus")
                        .HasColumnType("float");

                    b.Property<double>("AnguloRad")
                        .HasColumnType("float");

                    b.HasKey("ProjetilId");

                    b.ToTable("Projetil");
                });

            modelBuilder.Entity("ColisaoModel", b =>
                {
                    b.HasOne("PBL.Models.MeteoroModel", "Meteoro")
                        .WithMany("Colisoes")
                        .HasForeignKey("MeteoroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PBL.Models.ProjetilModel", "Projetil")
                        .WithMany("Colisoes")
                        .HasForeignKey("ProjetilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meteoro");

                    b.Navigation("Projetil");
                });

            modelBuilder.Entity("PBL.Models.MeteoroModel", b =>
                {
                    b.Navigation("Colisoes");
                });

            modelBuilder.Entity("PBL.Models.ProjetilModel", b =>
                {
                    b.Navigation("Colisoes");
                });
#pragma warning restore 612, 618
        }
    }
}
