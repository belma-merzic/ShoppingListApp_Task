using ShoppingListApp_API.Model;
using ShoppingListApp_API.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp_API.Services
{
    public interface IItemService : IBaseService<Item, ItemInsertRequest>
    {
    }
}
