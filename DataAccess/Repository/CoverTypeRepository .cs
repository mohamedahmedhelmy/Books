using DataAccess.Repository.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CoverTypeRepository : BaseRepository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _ctx;
        public CoverTypeRepository(ApplicationDbContext ctx):base(ctx)
        {
            _ctx = ctx;
        }
        public void Update(CoverType coverType)
        {
            _ctx.Update(coverType);
        }

    }
}
