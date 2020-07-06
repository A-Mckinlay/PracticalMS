using System;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model
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
