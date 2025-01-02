using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFGenericDal<T> : IGenericDal<T> where T : class
    {
        private readonly TechDBContext _context;
        private readonly DbSet<T> _dbSet;

        public EFGenericDal(TechDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void TCreate(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void TUpdate(T entity)
        {
            _context.SaveChanges();
        }

        public void TDelete(T entity)
        {
            _context.SaveChanges();
        }

        public T TGetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> TGetAll()
        {
            return _dbSet.ToList();
        }
    }
}