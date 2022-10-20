using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _ctx;
        public UnitOfWork(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            Product =new ProductRepository(ctx);
            Category =new CategoryRepository(ctx);
            CoverType =new CoverTypeRepository(ctx);
            Company =new CompanyRepository(ctx);
            ShoppingCart =new ShoppingCartRepository(ctx);
            ApplicationUser =new ApplicationUserRepository(ctx);
            OrderDetail =new OrderDetailRepository(ctx);
            OrderHeader =new OrderHeaderRepository(ctx);


        }
        public IProductRepository Product { get;private set; }

        public ICategoryRepository Category { get; private set; }

        public ICoverTypeRepository CoverType { get; private set; }

        public ICompanyRepository Company { get; private set; }

        public IShoppingCartRepository ShoppingCart { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IOrderDetailRepository OrderDetail  { get; private set; }
                                                 
        public IOrderHeaderRepository OrderHeader { get; private set; }

    public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
