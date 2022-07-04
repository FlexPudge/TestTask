using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestWebApplication.Data.Model
{
    public partial class TestDBContext : DbContext
    {
        public TestDBContext()
        {
        }

        public TestDBContext(DbContextOptions<TestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Analyzer> Analyzers { get; set; }
        public virtual DbSet<AnalyzerChannel> AnalyzerChannels { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-R3QCK61;Initial Catalog=TestDB;integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Analyzer>(entity =>
            {
                entity.ToTable("Analyzer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<AnalyzerChannel>(entity =>
            {
                entity.ToTable("AnalyzerChannel");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idanalyzer).HasColumnName("IDAnalyzer");

                entity.Property(e => e.Idchannel).HasColumnName("IDChannel");

                entity.HasOne(d => d.IdanalyzerNavigation)
                    .WithMany(p => p.AnalyzerChannels)
                    .HasForeignKey(d => d.Idanalyzer)
                    .HasConstraintName("FK_AnalyzerChannel_Analyzer");

                entity.HasOne(d => d.IdchannelNavigation)
                    .WithMany(p => p.AnalyzerChannels)
                    .HasForeignKey(d => d.Idchannel)
                    .HasConstraintName("FK_AnalyzerChannel_Channel");
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.ToTable("Channel");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsHot)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
