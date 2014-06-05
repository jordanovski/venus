using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Venus.Data;
using Venus.Interface;
using Venus.Model;

namespace Venus.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        readonly VenusContext context = new VenusContext();

        public IQueryable<Orders> All
        {
            get { return context.Orders; }
        }

        public IQueryable<Orders> AllIncluding(params Expression<Func<Orders, object>>[] includeProperties)
        {
            IQueryable<Orders> query = context.Orders;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Orders Find(int id)
        {
            return context.Orders.Find(id);
        }

        public void InsertOrUpdate(Orders orders)
        {
            if (orders.Id == default(int))
            {
                context.Orders.Add(orders);
            }
            else
            {
                context.Entry(orders).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var orders = context.Orders.Find(id);
            context.Orders.Remove(orders);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}