using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;



namespace Infraestructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly BipassDbContext _dbcontext;

        public BaseRepository(BipassDbContext bipassDbcontext)
        {
            _dbcontext = bipassDbcontext;
        }

        public List<T> Get()
        {
            return _dbcontext.Set<T>().ToList();
        }

        public T Get<TId>(TId id)
        {
            return _dbcontext.Set<T>().Find(new object[] {id});
        }
    }
}
