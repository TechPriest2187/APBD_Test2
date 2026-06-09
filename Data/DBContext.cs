using Microsoft.EntityFrameworkCore;
using Test2.Entities;

namespace Test2.Data
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Borrowing> Borrowings { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>().HasKey(c => c.MemberId);
            modelBuilder.Entity<Book>().HasKey(c => c.BookId);
            modelBuilder.Entity<Author>().HasKey(c => c.AuthorId);
            modelBuilder.Entity<Borrowing>()
                .HasKey(b => new { b.MemberId, b.BookId});
            modelBuilder.Entity<Review>()
                .HasKey(r => new { r.MemberId, r.BookId});
        }
    }
}