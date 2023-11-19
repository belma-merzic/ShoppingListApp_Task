using Microsoft.AspNetCore.Mvc;
using ShoppingListApp_API.Model;
using ShoppingListApp_API.Model.Requests;
using ShoppingListApp_API.Services;

namespace ShoppingListApp_API.Controllers
{
    [ApiController]
    public class ItemController : BaseController<Model.Item, ItemInsertRequest>
    {
        public ItemController(ILogger<BaseController<Item, ItemInsertRequest>> logger, IItemService service) 
            : base(logger, service)
        {
        }
    }
}
