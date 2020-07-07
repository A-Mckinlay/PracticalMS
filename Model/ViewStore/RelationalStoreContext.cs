using System;
using Microsoft.EntityFrameworkCore;
using Model.ViewStore.Entities;

namespace Model.ViewStore
{
    public class RelationalStoreContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }

        public RelationalStoreContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>()
                .Property(p => p.Id)
                .IsRequired();

            modelBuilder.Entity<Page>()
                .Property(p => p.PageName)
                .IsRequired();

            modelBuilder.Entity<Page>()
                .Property(p => p.PageData)
                .IsRequired();
        }
    }
}
