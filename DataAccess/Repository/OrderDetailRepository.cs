using DataAccess.Repository.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _ctx;
        public OrderDetailRepository(ApplicationDbContext ctx):base(ctx)
        {
            _ctx = ctx;
        }
        public void Update(OrderDetail orderDetail )
        {
            _ctx.Update(orderDetail);
        }
    }
}
