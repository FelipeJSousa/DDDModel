using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly MySqlContext _mySqlContext;

        public BaseRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public void Insert(T obj)
        {
            _mySqlContext.Set<T>().Add(obj);
            _mySqlContext.SaveChanges();
        }

        public void Update(T obj)
        {
            _mySqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _mySqlContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _mySqlContext.Set<T>().Remove(Select(id));
            _mySqlContext.SaveChanges();
        }

        public IList<T> Select() =>
            _mySqlContext.Set<T>().ToList();

        public T Select(int id) =>
            _mySqlContext.Set<T>().Find(id);
    }
}
