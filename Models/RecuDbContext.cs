using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RecuPj.Models
{
    public partial class RecuDbContext : DbContext
    {
        public RecuDbContext()
        {
        }

        public RecuDbContext(DbContextOptions<RecuDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banque> Banques { get; set; } = null!;
        public virtual DbSet<Cheque> Cheques { get; set; } = null!;
        public virtual DbSet<Demande> Demandes { get; set; } = null!;
        public virtual DbSet<Determination> Determinations { get; set; } = null!;
        public virtual DbSet<Echantillon> Echantillons { get; set; } = null!;
        public virtual DbSet<Facture> Factures { get; set; } = null!;
        public virtual DbSet<Recu> Recus { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banque>(entity =>
            {
                entity.HasKey(e => e.Na)
                    .HasName("PK__Banque__3214D55EBBAC26CC");

                entity.ToTable("Banque");

                entity.Property(e => e.Na)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NA");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("date")
                    .HasColumnName("dateCreation");

                entity.Property(e => e.Nom).HasColumnType("text");
            });

            modelBuilder.Entity<Cheque>(entity =>
            {
                entity.HasKey(e => e.Ncheque)
                    .HasName("PK__cheque__1AB8F46CDA817714");

                entity.ToTable("cheque");

                entity.Property(e => e.Ncheque).ValueGeneratedNever();

                entity.Property(e => e.Banque)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("banque");

                entity.Property(e => e.Beneficiare).HasColumnType("text");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Lieu).HasColumnType("text");

                entity.Property(e => e.MontantChiffres).HasColumnType("money");

                entity.Property(e => e.MontantLettre).HasColumnType("text");

                entity.HasOne(d => d.BanqueNavigation)
                    .WithMany(p => p.Cheques)
                    .HasForeignKey(d => d.Banque)
                    .HasConstraintName("FK__cheque__banque__72C60C4A");
            });

            modelBuilder.Entity<Demande>(entity =>
            {
                entity.HasKey(e => e.Ndum)
                    .HasName("PK__Demande__D0A5CB582EA7479C");

                entity.ToTable("Demande");

                entity.Property(e => e.Ndum)
                    .ValueGeneratedNever()
                    .HasColumnName("NDum");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Demandeur)
                    .HasColumnType("text")
                    .HasColumnName("demandeur");

                entity.HasOne(d => d.NlaboNavigation)
                    .WithMany(p => p.Demandes)
                    .HasForeignKey(d => d.Nlabo)
                    .HasConstraintName("FK__Demande__Nlabo__3B75D760");
            });

            modelBuilder.Entity<Determination>(entity =>
            {
                entity.HasKey(e => e.Desdet)
                    .HasName("PK__Determin__93F4C9409C7FE791");

                entity.ToTable("Determination");

                entity.Property(e => e.Desdet)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("desdet");

                entity.Property(e => e.Prix)
                    .HasColumnType("decimal(5, 5)")
                    .HasColumnName("prix");
            });

            modelBuilder.Entity<Echantillon>(entity =>
            {
                entity.HasKey(e => e.Nlabo)
                    .HasName("PK__Echantil__2CD04F1783A89919");

                entity.ToTable("Echantillon");

                entity.Property(e => e.Nlabo).ValueGeneratedNever();

                entity.Property(e => e.Desdet)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("desdet");

                entity.Property(e => e.Designation)
                    .HasColumnType("text")
                    .HasColumnName("designation");

                entity.HasOne(d => d.DesdetNavigation)
                    .WithMany(p => p.Echantillons)
                    .HasForeignKey(d => d.Desdet)
                    .HasConstraintName("FK__Echantill__desde__38996AB5");
            });

            modelBuilder.Entity<Facture>(entity =>
            {
                entity.HasKey(e => e.Nfacture)
                    .HasName("PK__Facture__3AA58632F5D2F94C");

                entity.ToTable("Facture");

                entity.Property(e => e.Nfacture).ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Demandeur)
                    .HasColumnType("text")
                    .HasColumnName("demandeur");

                entity.Property(e => e.Payeur)
                    .HasColumnType("text")
                    .HasColumnName("payeur");

                entity.HasOne(d => d.NlaboNavigation)
                    .WithMany(p => p.Factures)
                    .HasForeignKey(d => d.Nlabo)
                    .HasConstraintName("FK__Facture__Nlabo__3E52440B");
            });

            modelBuilder.Entity<Recu>(entity =>
            {
                entity.HasKey(e => e.Nemuro)
                    .HasName("PK__Recu__831E840891C83CDE");

                entity.ToTable("Recu");

                entity.Property(e => e.Nemuro).ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.ModePaiement)
                    .HasColumnType("text")
                    .HasColumnName("modePaiement");

                entity.Property(e => e.Nc).HasColumnName("NC");

                entity.Property(e => e.Payeur).HasColumnType("text");

                entity.HasOne(d => d.NcNavigation)
                    .WithMany(p => p.Recus)
                    .HasForeignKey(d => d.Nc)
                    .HasConstraintName("FK__Recu__NC__73BA3083");

                entity.HasOne(d => d.NdumNavigation)
                    .WithMany(p => p.Recus)
                    .HasForeignKey(d => d.Ndum)
                    .HasConstraintName("FK__Recu__Ndum__5CD6CB2B");

                entity.HasOne(d => d.NfNavigation)
                    .WithMany(p => p.Recus)
                    .HasForeignKey(d => d.Nf)
                    .HasConstraintName("FK__Recu__Nf__5DCAEF64");
            });

            modelBuilder.HasSequence<int>("sq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
