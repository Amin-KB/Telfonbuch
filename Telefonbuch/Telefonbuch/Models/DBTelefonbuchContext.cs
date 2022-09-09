using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Telefonbuch.Models
{
    public partial class DBTelefonbuchContext : DbContext
    {
        public DBTelefonbuchContext()
        {
        }

        public DBTelefonbuchContext(DbContextOptions<DBTelefonbuchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblTelefon> TblTelefons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=AMIN-PC\\SQLEXPRESS;Database=DBTelefonbuch;Trusted_Connection=False;User Id=sa;Password=33509110Karaj;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<TblTelefon>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__TblTelef__AA2FFBE53E4AB9B4");

                entity.ToTable("TblTelefon");

                entity.Property(e => e.Anrede)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Nachname).HasMaxLength(100);

                entity.Property(e => e.Ort).HasMaxLength(50);

                entity.Property(e => e.Telefon).HasMaxLength(50);

                entity.Property(e => e.Vorname).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
