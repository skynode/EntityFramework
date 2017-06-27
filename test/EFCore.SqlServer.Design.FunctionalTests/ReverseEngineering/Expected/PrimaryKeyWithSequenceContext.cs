using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E2ETest.Namespace
{
    public partial class PrimaryKeyWithSequenceContext : DbContext
    {
        public virtual DbSet<PrimaryKeyWithSequence> PrimaryKeyWithSequence { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"{{connectionString}}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrimaryKeyWithSequence>(entity =>
            {
                entity.Property(e => e.PrimaryKeyWithSequenceId).HasDefaultValueSql("(NEXT VALUE FOR [PrimaryKeyWithSequenceSequence])");
            });

            modelBuilder.HasSequence<int>("PrimaryKeyWithSequenceSequence");
        }
    }
}