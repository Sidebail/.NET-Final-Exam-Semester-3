namespace F2018Pranks.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Prank> Pranks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prank>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Prank>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Prank>()
                .Property(e => e.Photo)
                .IsUnicode(false);
        }
    }
}
