using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class ShoppingListService : BaseService<Model.ShoppingList, Database.ShoppingList, ShoppingListInsertRequest>, IShoppingListService
    {
        public ShoppingListService(TaskDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override bool Validate(ShoppingListInsertRequest insert)
        {
            var lists = _context.ShoppingLists.ToList();
            int limit = 3;

            if(lists.Where(x=>x.ItemId == insert.ItemId).Count() >= limit)
            {
                return false;
            }
            if(lists.Any(x=>x.ItemId == insert.ItemId && x.ShopperId == insert.ShopperId))
            {
                return false;
            }
            return true;
        }

        public override async Task<List<Model.ShoppingList>> GetById(int id)
        {
            var list = await _context.ShoppingLists.Where(x => x.ShopperId == id).ToListAsync();

            return _mapper.Map<List<Model.ShoppingList>>(list);
        }
    }
}
