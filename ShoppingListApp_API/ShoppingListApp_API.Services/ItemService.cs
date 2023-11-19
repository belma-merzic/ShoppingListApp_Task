using AutoMapper;
using ShoppingListApp_API.Model;
using ShoppingListApp_API.Model.Requests;
using ShoppingListApp_API.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp_API.Services
{
    public class ItemService : BaseService<Model.Item, Database.Item, ItemInsertRequest>, IItemService
    {
        public ItemService(TaskDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
