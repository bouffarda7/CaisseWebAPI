﻿// <auto-generated />
using System;
using CaisseWebAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaisseWebAPI.Migrations
{
    [DbContext(typeof(CaisseWebDbContext))]
    [Migration("20191023184839_AjoutRabais")]
    partial class AjoutRabais
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CaisseWebAPI.DAL.Adresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasColumnType("varchar(6)")
                        .HasMaxLength(6);

                    b.Property<string>("NumeroAppartement")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("NumeroCivique")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Rue")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Adresse");
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.CategorieProduit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DescriptionCategorie")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("NomCategorie")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<sbyte>("StatusCategorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValueSql("1");

                    b.HasKey("Id");

                    b.HasIndex("NomCategorie")
                        .IsUnique();

                    b.ToTable("CategorieProduit");
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.Compte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateInscription")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(75)")
                        .HasMaxLength(75);

                    b.Property<int>("IdAdresse")
                        .HasColumnType("int");

                    b.Property<string>("MotPasse")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("NomUtilisateur")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.Property<sbyte>("StatusCompte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValueSql("1");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdAdresse");

                    b.HasIndex("NomUtilisateur")
                        .IsUnique();

                    b.ToTable("Compte");
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.CompteTelephone", b =>
                {
                    b.Property<int>("IdCompte")
                        .HasColumnType("int");

                    b.Property<int>("IdTelephone")
                        .HasColumnType("int");

                    b.HasKey("IdCompte", "IdTelephone");

                    b.HasIndex("IdTelephone");

                    b.ToTable("CompteTelephone");
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.Employe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEmbauche")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("DateFinEmploi")
                        .HasColumnType("datetime");

                    b.Property<sbyte>("EstAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValueSql("0");

                    b.Property<int>("IdCompte")
                        .HasColumnType("int");

                    b.Property<string>("MotPasse")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("NomUtilisateur")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("IdCompte");

                    b.HasIndex("NomUtilisateur")
                        .IsUnique();

                    b.ToTable("Employe");
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodeProduit")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("DescriptionProduit")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("NomProduit")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("PrixProduit")
                        .HasColumnType("decimal(15,4)");

                    b.Property<int>("QuantiteProduit")
                        .HasColumnType("int");

                    b.Property<sbyte>("StatusProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValueSql("1");

                    b.HasKey("Id");

                    b.HasIndex("NomProduit")
                        .IsUnique();

                    b.ToTable("Produit");
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.Rabais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime");

                    b.Property<float>("Param1")
                        .HasColumnType("float");

                    b.Property<float>("Param2")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Rabais");
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.RelProduitCategorie", b =>
                {
                    b.Property<int>("IdProduit")
                        .HasColumnType("int");

                    b.Property<int>("IdCategorie")
                        .HasColumnType("int");

                    b.HasKey("IdProduit", "IdCategorie");

                    b.HasIndex("IdCategorie");

                    b.ToTable("RelProduitCategorie");
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.Telephone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdTypeTelephone")
                        .HasColumnType("int");

                    b.Property<string>("NumeroTelephone")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasIndex("IdTypeTelephone");

                    b.ToTable("Telephone");
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.TypeRabais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomType")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("NomType")
                        .IsUnique();

                    b.ToTable("TypeRabais");
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.TypeTelephone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomType")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("NomType")
                        .IsUnique();

                    b.ToTable("TypeTelephone");
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.Compte", b =>
                {
                    b.HasOne("CaisseWebAPI.DAL.Adresse", "Adresse")
                        .WithMany("Comptes")
                        .HasForeignKey("IdAdresse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.CompteTelephone", b =>
                {
                    b.HasOne("CaisseWebAPI.DAL.Compte", "Compte")
                        .WithMany("CompteTelephones")
                        .HasForeignKey("IdCompte")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaisseWebAPI.DAL.Telephone", "Telephone")
                        .WithMany("CompteTelephones")
                        .HasForeignKey("IdTelephone")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.Employe", b =>
                {
                    b.HasOne("CaisseWebAPI.DAL.Compte", "Compte")
                        .WithMany("Employe")
                        .HasForeignKey("IdCompte")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.RelProduitCategorie", b =>
                {
                    b.HasOne("CaisseWebAPI.DAL.CategorieProduit", "Categorie")
                        .WithMany("RelProduitCategories")
                        .HasForeignKey("IdCategorie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaisseWebAPI.DAL.Produit", "Produit")
                        .WithMany("RelProduitCategories")
                        .HasForeignKey("IdProduit")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaisseWebAPI.DAL.Telephone", b =>
                {
                    b.HasOne("CaisseWebAPI.DAL.TypeTelephone", "TypeTelephone")
                        .WithMany("Telephones")
                        .HasForeignKey("IdTypeTelephone")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
