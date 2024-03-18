using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary;

public class DataContext(DbContextOptions<DataContext> options)
  : DbContext(options) {
  public DbSet<AuthorModel> Authors { get; set; }
  public DbSet<GenreModel> Genres { get; set; }
  public DbSet<BookModel> Books { get; set; }
  public DbSet<BookTypeModel> BookTypes { get; set; }
  public DbSet<CartModel> Carts { get; set; }
  public DbSet<CartItemModel> CartItems { get; set; }
  public DbSet<DiscountModel> Discounts { get; set; }
  public DbSet<RoleModel> Roles { get; set; }
  public DbSet<UserModel> Users { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.Entity<BookModel>()
      .HasOne(b => b.AuthorModel)
      .WithMany(a => a.Books)
      .HasForeignKey(b => b.AuthorId);

    modelBuilder.Entity<BookModel>()
      .HasOne(b => b.GenreModel)
      .WithMany(g => g.Books)
      .HasForeignKey(b => b.GenreId);

    modelBuilder.Entity<BookModel>()
      .HasOne(b => b.DiscountModel)
      .WithMany(d => d.Books)
      .HasForeignKey(b => b.DiscountId).IsRequired(false);

    modelBuilder.Entity<UserModel>()
      .HasOne(u => u.RoleModel)
      .WithMany(r => r.Users)
      .HasForeignKey(u => u.RoleId);

    modelBuilder.Entity<CartItemModel>()
      .HasOne(c => c.BookModel)
      .WithMany(b => b.CartItems)
      .HasForeignKey(c => c.BookId);

    modelBuilder.Entity<CartItemModel>()
      .HasOne(c => c.BookTypeModel)
      .WithMany(bt => bt.CartItems)
      .HasForeignKey(c => c.BookTypeId);

    modelBuilder.Entity<CartItemModel>()
      .HasOne(ci => ci.CartModel)
      .WithMany(c => c.CartItems)
      .HasForeignKey(c => c.CartId);

    modelBuilder.Entity<CartModel>()
      .HasOne(c => c.UserModel)
      .WithMany(u => u.Carts)
      .HasForeignKey(c => c.UserId);
  }
}