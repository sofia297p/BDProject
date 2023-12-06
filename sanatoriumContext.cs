using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sanatorium
{
    public partial class sanatoriumContext : DbContext
    {
        public sanatoriumContext()
        {
        }

        public sanatoriumContext(DbContextOptions<sanatoriumContext> options)
            : base(options)
        {
        }
        static sanatoriumContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public virtual DbSet<Alcoholic> Alcoholics { get; set; } = null!;
        public virtual DbSet<AlcoholicInspector> AlcoholicInspectors { get; set; } = null!;
        public virtual DbSet<Bed> Beds { get; set; } = null!;
        public virtual DbSet<DrinkProcess> DrinkProcesses { get; set; } = null!;
        public virtual DbSet<DrinkType> DrinkTypes { get; set; } = null!;
        public virtual DbSet<EscapeFromBed> EscapeFromBeds { get; set; } = null!;
        public virtual DbSet<GroupAlcoholic> GroupAlcoholics { get; set; } = null!;
        public virtual DbSet<Groupa> Groupas { get; set; } = null!;
        public virtual DbSet<Inspector> Inspectors { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<PutAlcoholicBed> PutAlcoholicBeds { get; set; } = null!;
        public virtual DbSet<ReleaseAlcoholicBed> ReleaseAlcoholicBeds { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alcoholic>(entity =>
            {
                entity.ToTable("alcoholic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Consciousness).HasColumnName("consciousness");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Alcoholics)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("alcoholic_user_id_fkey");
            });

            modelBuilder.Entity<AlcoholicInspector>(entity =>
            {
                entity.ToTable("alcoholic_inspector");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.AlcoholicId).HasColumnName("alcoholic_id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.InspectorId).HasColumnName("inspector_id");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.Alcoholic)
                    .WithMany(p => p.AlcoholicInspectors)
                    .HasForeignKey(d => d.AlcoholicId)
                    .HasConstraintName("alcoholic_inspector_alcoholic_id_fkey");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.AlcoholicInspector)
                    .HasForeignKey<AlcoholicInspector>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("alcoholic_inspector_id_fkey");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.AlcoholicInspector)
                    .HasForeignKey<AlcoholicInspector>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("alcoholic_inspector_id_fkey1");

                entity.HasOne(d => d.Inspector)
                    .WithMany(p => p.AlcoholicInspectors)
                    .HasForeignKey(d => d.InspectorId)
                    .HasConstraintName("alcoholic_inspector_inspector_id_fkey");
            });

            modelBuilder.Entity<Bed>(entity =>
            {
                entity.ToTable("bed");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Number).HasColumnName("number");
            });

            modelBuilder.Entity<DrinkProcess>(entity =>
            {
                entity.ToTable("drink_process");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.DrinkTypeId).HasColumnName("drink_type_id");

                entity.Property(e => e.GroupAlcoholicId).HasColumnName("group_alcoholic_id");
            });

            modelBuilder.Entity<DrinkType>(entity =>
            {
                entity.ToTable("drink_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlcoholDegree).HasColumnName("alcohol_degree");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<EscapeFromBed>(entity =>
            {
                entity.ToTable("escape_from_bed");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlcoholicId).HasColumnName("alcoholic_id");

                entity.Property(e => e.BedId).HasColumnName("bed_id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.HasOne(d => d.Alcoholic)
                    .WithMany(p => p.EscapeFromBeds)
                    .HasForeignKey(d => d.AlcoholicId)
                    .HasConstraintName("escape_from_bed_alcoholic_id_fkey");

                entity.HasOne(d => d.Bed)
                    .WithMany(p => p.EscapeFromBeds)
                    .HasForeignKey(d => d.BedId)
                    .HasConstraintName("escape_from_bed_bed_id_fkey");
            });

            modelBuilder.Entity<GroupAlcoholic>(entity =>
            {
                entity.ToTable("group_alcoholic");

                entity.HasIndex(e => new { e.GroupId, e.AlcoholicId }, "group_alcoholic_group_id_alcoholic_id_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlcoholicId).HasColumnName("alcoholic_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.HasOne(d => d.Alcoholic)
                    .WithMany(p => p.GroupAlcoholics)
                    .HasForeignKey(d => d.AlcoholicId)
                    .HasConstraintName("group_alcoholic_alcoholic_id_fkey");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupAlcoholics)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("group_alcoholic_group_id_fkey");
            });

            modelBuilder.Entity<Groupa>(entity =>
            {
                entity.ToTable("groupa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupName)
                    .HasColumnType("character varying")
                    .HasColumnName("group_name");
            });

            modelBuilder.Entity<Inspector>(entity =>
            {
                entity.ToTable("inspector");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Inspectors)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("inspector_user_id_fkey");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthdate).HasColumnName("birthdate");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.Sex)
                    .HasColumnType("character varying")
                    .HasColumnName("sex");

                entity.Property(e => e.Surname)
                    .HasColumnType("character varying")
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<PutAlcoholicBed>(entity =>
            {
                entity.HasKey(e => e.PairId)
                    .HasName("put_alcoholic_bed_pkey");

                entity.ToTable("put_alcoholic_bed");

                entity.Property(e => e.PairId).HasColumnName("pair_id");

                entity.Property(e => e.BedId).HasColumnName("bed_id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.HasOne(d => d.Bed)
                    .WithMany(p => p.PutAlcoholicBeds)
                    .HasForeignKey(d => d.BedId)
                    .HasConstraintName("put_alcoholic_bed_bed_id_fkey");
            });

            modelBuilder.Entity<ReleaseAlcoholicBed>(entity =>
            {
                entity.HasKey(e => e.PairId)
                    .HasName("release_alcoholic_bed_pkey");

                entity.ToTable("release_alcoholic_bed");

                entity.Property(e => e.PairId).HasColumnName("pair_id");

                entity.Property(e => e.BedId).HasColumnName("bed_id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.HasOne(d => d.Bed)
                    .WithMany(p => p.ReleaseAlcoholicBeds)
                    .HasForeignKey(d => d.BedId)
                    .HasConstraintName("release_alcoholic_bed_bed_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
