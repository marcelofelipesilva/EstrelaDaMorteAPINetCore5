﻿// <auto-generated />
using System;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstrelaDaMorteAPI.Migrations
{
    [DbContext(typeof(EstrelaDaMorteDbContext))]
    [Migration("20210916184741_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Business.Entities.Nave", b =>
                {
                    b.Property<int>("IdNave")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Carga")
                        .HasColumnType("float");

                    b.Property<string>("Classe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Passageiros")
                        .HasColumnType("int");

                    b.Property<int?>("PilotoIdPiloto")
                        .HasColumnType("int");

                    b.HasKey("IdNave");

                    b.HasIndex("PilotoIdPiloto");

                    b.ToTable("TB_NAVE");
                });

            modelBuilder.Entity("Business.Entities.Piloto", b =>
                {
                    b.Property<int>("IdPiloto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnoNascimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPlaneta")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPiloto");

                    b.HasIndex("IdPlaneta");

                    b.ToTable("TB_PILOTO");
                });

            modelBuilder.Entity("Business.Entities.Planeta", b =>
                {
                    b.Property<int>("IdPlaneta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clima")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Diametro")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Orbita")
                        .HasColumnType("float");

                    b.Property<int>("Populacao")
                        .HasColumnType("int");

                    b.Property<double>("Rotacao")
                        .HasColumnType("float");

                    b.HasKey("IdPlaneta");

                    b.ToTable("TB_PLANETA");
                });

            modelBuilder.Entity("Business.Entities.Nave", b =>
                {
                    b.HasOne("Business.Entities.Piloto", null)
                        .WithMany("Naves")
                        .HasForeignKey("PilotoIdPiloto");
                });

            modelBuilder.Entity("Business.Entities.Piloto", b =>
                {
                    b.HasOne("Business.Entities.Planeta", "Planeta")
                        .WithMany()
                        .HasForeignKey("IdPlaneta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planeta");
                });

            modelBuilder.Entity("Business.Entities.Piloto", b =>
                {
                    b.Navigation("Naves");
                });
#pragma warning restore 612, 618
        }
    }
}
