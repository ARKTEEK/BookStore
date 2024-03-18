using DataLibrary.Interfaces;
using DataLibrary.Models;

namespace DataLibrary.Repositories;

public class AuthorRepository(DataContext context) : IRepository<AuthorModel> {
  public List<AuthorModel> GetAll() {
    List<AuthorModel> authors = context.Authors.ToList();

    return authors;
  }

  public AuthorModel GetById(int key) {
    AuthorModel? author = context.Authors.FirstOrDefault(a => a.Id == key);

    return author;
  }

  public void Add(AuthorModel authorModel) {
    context.Authors.Add(authorModel);
    context.SaveChanges();
  }

  public void Update(AuthorModel authorModel) {
    context.Authors.Update(authorModel);
    context.SaveChanges();
  }

  public void Delete(int key) {
    AuthorModel? author = context.Authors.FirstOrDefault(a => a.Id == key);

    if (author == null) return;

    context.Authors.Remove(author);
    context.SaveChanges();
  }
}