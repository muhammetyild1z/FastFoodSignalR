using FastFoodSignalR.DataAccessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly FastFoodContext _context;

        public GenericRepository(FastFoodContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T GetById(int Id)
        {
          return _context.Set<T>().Find(Id);
        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
