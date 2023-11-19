using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShoppingListApp_API.Model;
using ShoppingListApp_API.Model.Requests;
using ShoppingListApp_API.Services.Database;

namespace ShoppingListApp_API.Services
{
    public class ShopperService : BaseService<Model.Shopper, Database.Shopper, ShopperInsertRequest>, IShopperService
    {
        public ShopperService(TaskDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
