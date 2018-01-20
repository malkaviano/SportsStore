using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Order> Orders => context.Orders
                                                    .Include(o => o.Details)
                                                    .Include(o => o.Items)
                                                    .ThenInclude(i => i.Product);

        public void SaveOrder(Order order)
        {
            if (order.Id == Guid.Empty)
            {
                context.AttachRange(order.Items);

                context.Orders.Add(order);
            }
            else
            {
                context.Orders.Update(order);
            }

            context.SaveChanges();
        }
    }
}
