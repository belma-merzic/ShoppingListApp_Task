using Microsoft.AspNetCore.Mvc;
using ShoppingListApp_API.Model;
using ShoppingListApp_API.Model.Requests;
using ShoppingListApp_API.Services;

namespace ShoppingListApp_API.Controllers
{
    [ApiController]
    public class ShoppingListController : BaseController<Model.ShoppingList, ShoppingListInsertRequest>
    {
        public ShoppingListController(ILogger<BaseController<ShoppingList, ShoppingListInsertRequest>> logger, IShoppingListService service) : base(logger, service)
        {
        }
    }
}
