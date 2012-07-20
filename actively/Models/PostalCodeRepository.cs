using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace actively.Models
{
    public class PostalCodeRepository : IPostalCodeRepository
    {
        ActivelyContext context = new ActivelyContext();

        public IQueryable<PostalCode> All
        {
            get { return context.Postalcodes; }
        }

        public IQueryable<PostalCode> AllIncluding(params Expression<Func<PostalCode, object>>[] includeProperties)
        {
            IQueryable<PostalCode> query = context.Postalcodes;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public PostalCode Find(int id)
        {
            return context.Postalcodes.Find(id);
        }

        public void InsertOrUpdate(PostalCode PostalCode)
        {
            if (PostalCode.Id == default(int))
            {
                // New entity
                context.Postalcodes.Add(PostalCode);
            }
            else
            {
                // Existing entity
                context.Entry(PostalCode).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var PostalCode = context.Postalcodes.Find(id);
            context.Postalcodes.Remove(PostalCode);
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

    public interface IPostalCodeRepository : IDisposable
    {
        IQueryable<PostalCode> All { get; }
        IQueryable<PostalCode> AllIncluding(params Expression<Func<PostalCode, object>>[] includeProperties);
        PostalCode Find(int id);
        void InsertOrUpdate(PostalCode PostalCode);
        void Delete(int id);
        void Save();
    }
}