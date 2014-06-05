using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Venus.Data;
using Venus.Interface;
using Venus.Model;

namespace Venus.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        readonly VenusContext context = new VenusContext();

        public IQueryable<Products> All
        {
            get { return context.Products; }
        }

        public IQueryable<Products> AllIncluding(params Expression<Func<Products, object>>[] includeProperties)
        {
            IQueryable<Products> query = context.Products;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Products Find(int id)
        {
            return context.Products.Find(id);
        }

        public void InsertOrUpdate(Products products)
        {
            if (products.Id == default(int))
            {
                context.Entry(products).State = EntityState.Added;
            }
            else
            {
                context.Products.Add(products);
                context.Entry(products).State = StateHelpers.ConvertState(products.State);                
            }
        }

        public void Delete(int id)
        {
            var products = context.Products.Find(id);
            context.Products.Remove(products);
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