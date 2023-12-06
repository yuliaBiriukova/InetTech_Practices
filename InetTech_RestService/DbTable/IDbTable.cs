namespace InetTech_RestService.DbTable;

public interface IDbTable<T> where T : class
{
    int Add(T entity);

    bool Delete(int id);

    List<T> GetAll();

    T? GetById(int id);

    bool Update(T entity);
}