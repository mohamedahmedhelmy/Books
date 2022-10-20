using DataAccess.Repository.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderHeaderRepository : BaseRepository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _ctx;
        public OrderHeaderRepository(ApplicationDbContext ctx):base(ctx)
        {
            _ctx = ctx;
        }
        public void Update(OrderHeader orderHeader )
        {
            _ctx.Update(orderHeader);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDB = _ctx.OrderHeaders.FirstOrDefault(p=>p.Id == id);
            if (orderFromDB != null)
            {
                orderFromDB.OrderStatus = orderStatus;
                if (paymentStatus!=null)
                {
                    orderFromDB.PaymentStatus = paymentStatus;
                }
            }
        }
        public void UpdateStripePaymentID(int id, string sessionId, string paymentItentId)
        {
            var orderFromDB = _ctx.OrderHeaders.FirstOrDefault(u => u.Id == id);
            orderFromDB.PaymentDate = DateTime.Now;
            orderFromDB.SessionId = sessionId;
            orderFromDB.PaymentIntentId = paymentItentId;
        }
    }
}
