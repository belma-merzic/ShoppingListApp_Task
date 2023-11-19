using ShoppingListApp_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp_API.Services
{
    public interface IBaseService<T, TInsert> where TInsert : class
    {
        Task<T> Insert(TInsert insert);
        Task<List<T>> Get();
        Task<List<T>> GetById(int id);
    }
}
