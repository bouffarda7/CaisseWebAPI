using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class CaisseWebDbContext : DbContext
    {
        public DbSet<Adresse> Adresse { get; set; }
        public DbSet<TypeTelephone> TypeTelephone { get; set; }
        public DbSet<Telephone> Telephone { get; set; }
        public DbSet<CompteTelephone> CompteTelephone { get; set; }
        public DbSet<Compte> Compte { get; set; }
        public DbSet<Employe> Employe { get; set; }
        public DbSet<CategorieProduit> CategorieProduit { get; set; }
        public DbSet<Produit> Produit { get; set; }
        public DbSet<RelProduitCategorie> RelProduitCategorie { get; set; }
        public DbSet<TypeRabais> TypeRabais { get; set; }
        public DbSet<Rabais> Rabais { get; set; }
        public DbSet<Facture> Facture { get; set; }
        public DbSet<LigneFacture> LigneFacture { get; set; }

        public CaisseWebDbContext(DbContextOptions<CaisseWebDbContext> options) : base(options)
        {
            //Database.Migrate();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Adresse>(entity => {

                entity.HasKey(a => a.Id);
                entity.Property(a => a.NumeroCivique).HasMaxLength(10).IsRequired();
                entity.Property(a => a.Rue).HasMaxLength(25).IsRequired();
                entity.Property(a => a.Ville).HasMaxLength(50).IsRequired();
                entity.Property(a => a.CodePostal).HasMaxLength(6).IsRequired();
                entity.Property(a => a.NumeroAppartement).HasMaxLength(5);

            });

            modelBuilder.Entity<TypeTelephone>(entity =>
            {
                entity.HasKey(typetel => typetel.Id);
                entity.Property(typetel => typetel.NomType).HasMaxLength(15).IsRequired();

                entity.HasIndex(typetel => typetel.NomType).IsUnique();
            });

            modelBuilder.Entity<Telephone>(entity =>
            {
                entity.HasKey(tel => tel.Id);
                entity.Property(tel => tel.NumeroTelephone).HasMaxLength(11).IsRequired();
                entity.HasOne(tel => tel.TypeTelephone).WithMany(type => type.Telephones).HasForeignKey(tel => tel.IdTypeTelephone);
            });

            modelBuilder.Entity<Compte>(entity =>
            {
                entity.HasKey(compte => compte.Id);
                entity.Property(compte => compte.Nom).HasMaxLength(25).IsRequired();
                entity.Property(compte => compte.Prenom).HasMaxLength(25).IsRequired();
                entity.Property(compte => compte.Email).HasMaxLength(75).IsRequired();
                entity.Property(compte => compte.NomUtilisateur).HasMaxLength(15).IsRequired();
                entity.Property(compte => compte.MotPasse).HasMaxLength(60).IsRequired();
                entity.Property(compte => compte.DateInscription).IsRequired().HasColumnType("datetime");
                entity.Property(compte => compte.DateNaissance).IsRequired().HasColumnType("datetime");
                entity.Property(compte => compte.StatusCompte).IsRequired().HasDefaultValue(1);
                entity.HasOne(compte => compte.Adresse).WithMany(adresse => adresse.Comptes).HasForeignKey(compte => compte.IdAdresse);
           
                entity.HasIndex(compte => compte.Email).IsUnique();
                entity.HasIndex(compte => compte.NomUtilisateur).IsUnique();

            });

            modelBuilder.Entity<CompteTelephone>(entity =>
            {
                entity.HasKey(comptetel => new { comptetel.IdCompte, comptetel.IdTelephone });
                entity.HasOne(comptetel => comptetel.Compte).WithMany(compte => compte.CompteTelephones).HasForeignKey(comptel => comptel.IdCompte);
                entity.HasOne(comptetel => comptetel.Telephone).WithMany(telephone => telephone.CompteTelephones).HasForeignKey(comptel => comptel.IdTelephone);
            });

            modelBuilder.Entity<Employe>(entity => 
            {
                entity.HasKey(employe => employe.Id);
                entity.Property(employe => employe.NomUtilisateur).HasMaxLength(25).IsRequired();
                entity.Property(employe => employe.MotPasse).HasMaxLength(60).IsRequired();
                entity.Property(employe => employe.EstAdmin).IsRequired().HasDefaultValue(0);
                entity.Property(employe => employe.DateEmbauche).IsRequired().HasColumnType("datetime").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(employe => employe.DateFinEmploi).HasColumnType("datetime");

                entity.HasOne(employe => employe.Compte).WithMany(compte => compte.Employe).HasForeignKey(e =>e.IdCompte);
                entity.HasIndex(employe => employe.NomUtilisateur).IsUnique();
            });

            modelBuilder.Entity<CategorieProduit>(entity =>
            {
                entity.HasKey(categorieprod => categorieprod.Id);
                entity.Property(categorieprod => categorieprod.NomCategorie).HasMaxLength(50).IsRequired();
                entity.Property(categorieprod => categorieprod.DescriptionCategorie).HasMaxLength(250);
                entity.Property(categorieprod => categorieprod.StatusCategorie).IsRequired().HasDefaultValueSql("1");

                entity.HasIndex(categorieprod => categorieprod.NomCategorie).IsUnique();

            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(produit => produit.Id);
                entity.Property(produit => produit.CodeProduit).HasMaxLength(60).IsRequired();

                entity.Property(produit => produit.NomProduit).HasMaxLength(50).IsRequired();
                entity.Property(produit => produit.DescriptionProduit).HasMaxLength(250);
                entity.Property(produit => produit.PrixProduit).IsRequired().HasColumnType("decimal(15,4)");
                entity.Property(produit => produit.QuantiteProduit).IsRequired();
                entity.Property(produit => produit.StatusProduit).IsRequired().HasDefaultValueSql("1");

                entity.HasIndex(produit => produit.NomProduit).IsUnique();
                entity.HasOne(produit => produit.Rabais).WithMany(rabais => rabais.Produits).HasForeignKey(produit => produit.IdRabais).IsRequired(false);


            });


            modelBuilder.Entity<RelProduitCategorie>(entity =>
            {
                entity.HasKey(relprodcat => new { relprodcat.IdProduit, relprodcat.IdCategorie });
                entity.HasOne(relprodcat => relprodcat.Produit).WithMany(produit => produit.RelProduitCategories).HasForeignKey(relprodcat => relprodcat.IdProduit);
                entity.HasOne(relprodcat => relprodcat.Categorie).WithMany(categorie => categorie.RelProduitCategories).HasForeignKey(relprodcat => relprodcat.IdCategorie);
            });

            modelBuilder.Entity<TypeRabais>(entity =>
            {
                entity.HasKey(typerabais => typerabais.Id);
                entity.Property(typerabais => typerabais.NomType).HasMaxLength(60).IsRequired();

                entity.HasIndex(typerabais => typerabais.NomType).IsUnique();
            });

            modelBuilder.Entity<Rabais>(entity =>
            {
                entity.HasKey(rabais => rabais.Id);
                entity.Property(rabais => rabais.DateDebut).IsRequired().HasColumnType("datetime");
                entity.Property(rabais => rabais.DateFin).IsRequired().HasColumnType("datetime");
                entity.Property(rabais => rabais.Param1).IsRequired().HasColumnType("float");
                entity.Property(rabais => rabais.Param2).IsRequired(false).HasColumnType("float");

                entity.HasOne(rabais => rabais.TypeRabais).WithMany(typerabais => typerabais.Rabais).HasForeignKey(rabais => rabais.IdTypeRabais);

            });

            modelBuilder.Entity<Facture>(entity =>
            {
                entity.HasKey(facture => facture.Id);
                entity.Property(facture => facture.DateFacture).IsRequired().HasColumnType("datetime").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(facture => facture.SousTotal).IsRequired().HasColumnType("decimal(15,4)").HasDefaultValue(0.0);
                entity.Property(facture => facture.TotalTaxe).IsRequired().HasColumnType("decimal(15,4)").HasDefaultValue(0.0);
                entity.Property(facture => facture.TotalAvecTaxe).IsRequired().HasColumnType("decimal(15,4)").HasDefaultValue(0.0); 
                entity.Property(facture => facture.CommentaireFacture).HasColumnType("varchar(250)");

                entity.HasOne(facture => facture.Compte).WithMany(compte => compte.Factures).HasForeignKey(facture => facture.IdCompte);
                entity.HasOne(facture => facture.Employe).WithMany(employe => employe.Factures).HasForeignKey(facture => facture.IdEmploye);
                entity.HasOne(facture => facture.RabaisFacture).WithMany(rabais => rabais.Factures).HasForeignKey(facture => facture.IdRabais);


            });


            modelBuilder.Entity<LigneFacture>(entity =>
            {
                entity.HasKey(lignefacture => new { lignefacture.IdFacture, lignefacture.IdProduit });
                entity.Property(lignefacture => lignefacture.Quantite).IsRequired();
                entity.Property(lignefacture => lignefacture.PrixRegulier).IsRequired().HasColumnType("decimal(15,4)");
                entity.Property(lignefacture => lignefacture.PrixAvecRabais).HasColumnType("decimal(15,4)");
                entity.Property(lignefacture => lignefacture.PrixTotalLigne).IsRequired().HasColumnType("decimal(15,4)");


                entity.HasOne(lignefacture => lignefacture.Produit).WithMany(produit => produit.LignesFacture).HasForeignKey(lignefacture => lignefacture.IdProduit);
                entity.HasOne(lignefacture => lignefacture.Facture).WithMany(facture => facture.LignesFacture).HasForeignKey(lignefacture => lignefacture.IdFacture);
            });

        }
    }
}
