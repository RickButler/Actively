using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace actively.Models
{
    public class PlaceRepository : IPlaceRepository
    {
        ActivelyContext context = new ActivelyContext();

        public IQueryable<Place> All
        {
            get { return context.Places; }
        }

        public IQueryable<Place> AllIncluding(params Expression<Func<Place, object>>[] includeProperties)
        {
            IQueryable<Place> query = context.Places;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Place Find(int id)
        {
            return context.Places.Find(id);
        }

        public void InsertOrUpdate(Place Place)
        {
            if (Place.Id == default(int))
            {
                // New entity
                context.Places.Add(Place);
            }
            else
            {
                // Existing entity
                context.Entry(Place).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var Place = context.Places.Find(id);
            context.Places.Remove(Place);
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

    public interface IPlaceRepository : IDisposable
    {
        IQueryable<Place> All { get; }
        IQueryable<Place> AllIncluding(params Expression<Func<Place, object>>[] includeProperties);
        Place Find(int id);
        void InsertOrUpdate(Place Place);
        void Delete(int id);
        void Save();
    }
}