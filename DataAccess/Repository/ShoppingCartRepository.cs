using DataAccess.Repository.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _ctx;
        public ShoppingCartRepository(ApplicationDbContext ctx):base(ctx)
        {
            _ctx = ctx;
        }

        public int DeCrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            return shoppingCart.Count;
        }

        public int InCrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count +=count;
            return shoppingCart.Count;
        }
    }
}
