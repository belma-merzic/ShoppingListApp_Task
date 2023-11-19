using Microsoft.AspNetCore.Mvc;
using ShoppingListApp_API.Model;
using ShoppingListApp_API.Services;

namespace ShoppingListApp_API.Controllers
{
    [Route("[controller]")]
    public class BaseController<T, TInsert> : ControllerBase where T : class where TInsert : class
    {
        protected readonly IBaseService<T, TInsert> _service;
        protected readonly ILogger<BaseController<T, TInsert>> _logger;

        public BaseController(ILogger<BaseController<T, TInsert>> logger, IBaseService<T, TInsert> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet()]
        public async Task<List<T>> Get()
        {
            return await _service.Get();
        }


        [HttpGet("{id}")]
        public async Task<List<T>> GetById(int id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public virtual async Task<T> Insert([FromBody] TInsert insert)
        {
            return await _service.Insert(insert);
        }
    }
}
