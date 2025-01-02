using System.Collections.Generic;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface IGenericDal<T> where T : class
    {
        void TCreate(T entity);
        void TUpdate(T entity);
        void TDelete(T entity);
        T TGetById(int id);
        IEnumerable<T> TGetAll();
    }
}
