using System.Collections.Generic;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface IGenericService<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
