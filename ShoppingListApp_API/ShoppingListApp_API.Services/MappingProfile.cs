using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp_API.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Shopper, Model.Shopper>();
            CreateMap<Model.Requests.ShopperInsertRequest, Database.Shopper>();

            CreateMap<Database.Item, Model.Item>();
            CreateMap<Model.Requests.ItemInsertRequest, Database.Item>();

            CreateMap<Database.ShoppingList, Model.ShoppingList>();
            CreateMap<Model.Requests.ShoppingListInsertRequest, Database.ShoppingList>();
        }
    }
}
