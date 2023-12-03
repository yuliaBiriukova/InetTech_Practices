using InetTech_SoapService.Entities;

namespace InetTech_SoapService.DbTable;

public class DbTable<T> : IDbTable<T> where T : Entity
{
    private List<T> Entities { get; set; } = new List<T>();
    private int Index { get; set; } = 0;

    public int Add(T entity)
    {
        Index++;
        entity.Id = Index;
        Entities.Add(entity);
        return Index;
    }

    public void Clear()
    {
        Entities.Clear();
        Index = 0;
    }

    public bool Delete(int id)
    {
        Entities.RemoveAll(entity => entity.Id == id);
        return Entities.Any(entity => entity.Id == id);
    }

    public List<T> GetAll()
    {
        return Entities;
    }

    public T? GetById(int id)
    {
        return Entities.FirstOrDefault(entity => entity.Id == id);
    }

    public int Size()
    {
        return Entities.Count;
    }

    public bool Update(T entity)
    {
        int index = Entities.FindIndex(item => item.Id == entity.Id);

        if (index >= 0)
        {
            Entities[index] = entity;
            return true;
        }

        return false;
    }
}
