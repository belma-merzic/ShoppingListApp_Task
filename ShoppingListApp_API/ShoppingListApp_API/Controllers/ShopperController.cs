using Microsoft.AspNetCore.Mvc;
using ShoppingListApp_API.Model.Requests;
using ShoppingListApp_API.Services;

namespace ShoppingListApp_API.Controllers
{
    [ApiController]
    public class ShopperController : BaseController<Model.Shopper, ShopperInsertRequest>
    {
        public ShopperController(ILogger<BaseController<Model.Shopper, ShopperInsertRequest>> logger, IShopperService service)
           : base(logger, service)
        {
        }
    }
}
