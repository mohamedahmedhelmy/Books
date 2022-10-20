using DataAccess.Repository.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _ctx;
        public CategoryRepository(ApplicationDbContext ctx):base(ctx)
        {
            _ctx = ctx;
        }
        public void Update(Category category)
        {
            _ctx.Update(category);
        }
    }
}
