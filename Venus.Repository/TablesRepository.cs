using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Venus.Data;
using Venus.Interface;
using Venus.Model;

namespace Venus.Repository
{
    public class TablesRepository : ITablesRepository
    {
        readonly VenusContext context = new VenusContext();

        public IQueryable<Tables> All
        {
            get { return context.Tables; }
        }

        public IQueryable<Tables> AllIncluding(params Expression<Func<Tables, object>>[] includeProperties)
        {
            IQueryable<Tables> query = context.Tables;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Tables Find(int id)
        {
            return context.Tables.Find(id);
        }

        public void InsertOrUpdate(Tables tables)
        {
            if (tables.Id == default(int))
            {
                context.Tables.Add(tables);
            }
            else
            {
                context.Entry(tables).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var tables = context.Tables.Find(id);
            context.Tables.Remove(tables);
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