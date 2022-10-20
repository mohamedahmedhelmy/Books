using DataAccess.Repository.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _ctx;
        public CompanyRepository(ApplicationDbContext ctx):base(ctx)
        {
            _ctx = ctx;
        }
        public void Update(Company company)
        {
            _ctx.Update(company);
        }
    }
}
