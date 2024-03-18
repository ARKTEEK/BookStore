using DataLibrary.Interfaces;
using DataLibrary.Models;

namespace DataLibrary.Repositories;

public class GenreRepository(DataContext context) : IRepository<GenreModel> {
  public List<GenreModel> GetAll() {
    List<GenreModel> genres = context.Genres.ToList();

    return genres;
  }

  public GenreModel GetById(int key) {
    GenreModel? genre = context.Genres.FirstOrDefault(g => g.Id == key);

    return genre;
  }

  public void Add(GenreModel genre) {
    context.Genres.Add(genre);
    context.SaveChanges();
  }

  public void Update(GenreModel genre) {
    context.Genres.Update(genre);
    context.SaveChanges();
  }

  public void Delete(int key) {
    GenreModel? genre = context.Genres.FirstOrDefault(g => g.Id == key);

    if (genre == null) return;

    context.Genres.Remove(genre);
    context.SaveChanges();
  }
}