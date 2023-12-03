namespace InetTech_SoapService.DbTable;

public interface IDbTable<T> where T : class
{
    int Add(T entity);

    void Clear();

    bool Delete(int id);

    List<T> GetAll();

    T? GetById(int id);

    int Size();

    bool Update(T entity);
}