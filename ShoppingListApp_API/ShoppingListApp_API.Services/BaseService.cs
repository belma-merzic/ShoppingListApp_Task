using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingListApp_API.Model;
using ShoppingListApp_API.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp_API.Services
{
    public class BaseService<T, TDb , TInsert>  : IBaseService<T, TInsert> where T : class where TDb : class where TInsert : class
    {

        protected TaskDbContext _context;
        protected IMapper _mapper { get; set; }
        public BaseService(TaskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<T> Insert(TInsert insert)
        {
            var set = _context.Set<TDb>();
            TDb entity = _mapper.Map<TDb>(insert);

            bool canAddItemToList = Validate(insert);

            if (!canAddItemToList)
            {
                throw new UserException("Cannot insert item due to limit");
            }

            set.Add(entity);

            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }

        public virtual bool Validate(TInsert insert)
        {
            return true;
        }

        public virtual async Task<List<T>> Get()
        {
            var query = _context.Set<TDb>().AsQueryable();

            var list = await query.ToListAsync();

            var result = _mapper.Map<List<T>>(list);

            return result;
        }


        public virtual async Task<List<T>> GetById(int id)
        {
            var entity = await _context.Set<TDb>().FindAsync(id);

            return _mapper.Map<List<T>>(entity);
        }
    }
}
