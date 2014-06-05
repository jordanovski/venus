using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Venus.Data;
using Venus.Interface;
using Venus.Model;

namespace Venus.Repository
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        readonly VenusContext context = new VenusContext();

        public IQueryable<OrderDetails> All
        {
            get { return context.OrderDetails; }
        }

        public IQueryable<OrderDetails> AllIncluding(params Expression<Func<OrderDetails, object>>[] includeProperties)
        {
            IQueryable<OrderDetails> query = context.OrderDetails;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public OrderDetails Find(int id)
        {
            return context.OrderDetails.Find(id);
        }

        public void InsertOrUpdate(OrderDetails orderdetails)
        {
            if (orderdetails.Id == default(int))
            {
                context.OrderDetails.Add(orderdetails);
            }
            else
            {
                context.Entry(orderdetails).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var orderdetails = context.OrderDetails.Find(id);
            context.OrderDetails.Remove(orderdetails);
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