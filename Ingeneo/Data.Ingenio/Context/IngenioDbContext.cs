namespace Data.Ingenio.Context
{
    using Domain.Ingenio.Entity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IngenioDbContext : DbContext
    {
        public IngenioDbContext(DbContextOptions<IngenioDbContext> dbContext) : base(dbContext) { }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder is null)
                throw new ArgumentException(nameof(ModelBuilder));
            base.OnModelCreating(builder);

            builder.Entity<Author>(ConfigureAuthor);
            builder.Entity<Book>(ConfigureBook);
            builder.Entity<User>(ConfigureUsers);
        }

        private void ConfigureAuthor(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired(true).HasColumnName("Id");
        }

        private void ConfigureBook(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired(true).HasColumnName("Id");
        }
        
        private void ConfigureUsers(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
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
