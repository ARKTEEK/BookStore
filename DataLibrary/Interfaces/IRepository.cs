namespace DataLibrary.Interfaces;

public interface IRepository<Type> {
  List<Type> GetAll();
  Type GetById(int key);
  void Add(Type obj);
  void Update(Type obj);
  void Delete(int key);
}