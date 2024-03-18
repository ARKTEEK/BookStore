using DataLibrary.Interfaces;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Repositories;

public class BookRepository(DataContext context) : IRepository<BookModel> {
  public List<BookModel> GetAll() {
    List<BookModel> books = context.Books
      .Include(b => b.AuthorModel)
      .Include(b => b.GenreModel)
      .Include(b => b.DiscountModel).ToList();

    return books;
  }

  public BookModel GetById(int id) {
    BookModel? book = context.Books
      .Include(b => b.AuthorModel)
      .Include(b => b.GenreModel)
      .Include(b => b.DiscountModel)
      .FirstOrDefault(b => b.Id == id);

    return book;
  }

  public void Add(BookModel bookModel) {
    context.Books.Add(bookModel);
    context.SaveChanges();
  }

  public void Update(BookModel bookModel) {
    context.Books.Update(bookModel);
    context.SaveChanges();
  }

  public void Delete(int id) {
    BookModel? book = context.Books.FirstOrDefault(b => b.Id == id);

    if (book == null) return;

    context.Books.Remove(book);
    context.SaveChanges();
  }
}