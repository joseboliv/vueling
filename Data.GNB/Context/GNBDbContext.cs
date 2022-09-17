namespace Data.GNB.Context
{
    using Domain.GNB.Entity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GNBDbContext : DbContext
    {
        public GNBDbContext(DbContextOptions<GNBDbContext> dbContext) : base(dbContext) { }

        public DbSet<RateEntity> Rate { get; set; }
        public DbSet<TransactionEntity> Transaction { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder is null)
                throw new ArgumentException(nameof(ModelBuilder));
            base.OnModelCreating(builder);

            builder.Entity<RateEntity>(ConfigureRates);
            builder.Entity<TransactionEntity>(ConfigureTransactions);

        }

        private void ConfigureRates(EntityTypeBuilder<RateEntity> builder)
        {
            builder.ToTable("Rates");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired(true).HasColumnName("Id");
        }

        private void ConfigureTransactions(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired(true).HasColumnName("Id");
        }

        private static void CancelDeleteCascade(ModelBuilder builder)
        {
            IEnumerable<IMutableForeignKey> ListCascadeFKs = builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (IMutableForeignKey fk in ListCascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
