using AliNino.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliNino.Core.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        public Task AddAsync(T model);
        public Task<T> GetAsync(Func<T,bool> expression);
        public Task<List<T>> GetAllAsync();
        public Task RemoveAsync(T model);


    }
}
