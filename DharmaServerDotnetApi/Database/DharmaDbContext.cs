using DharmaServerDotnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DharmaServerDotnetApi.Database;

public class DharmaDbContext : DbContext {

    public DharmaDbContext( DbContextOptions<DharmaDbContext> options ) : base( options ) { }

    public DbSet<User> User { get; set; }
    public DbSet<Library> Library { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<LibraryBook> LibraryBook { get; set; }

    protected override void OnModelCreating( ModelBuilder modelBuilder ) {
        modelBuilder.Entity<LibraryBook>()
                .HasKey( libBook => libBook.Id );

        modelBuilder.Entity<LibraryBook>()
                .HasOne( book => book.Book )
                .WithMany( libBook => libBook.LibraryBooks )
                .HasForeignKey( book => book.BookId );

        modelBuilder.Entity<LibraryBook>()
                .HasOne( lib => lib.Library )
                .WithMany( libBook => libBook.LibraryBooks )
                .HasForeignKey( lib => lib.LibraryId );
    }

}