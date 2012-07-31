using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Data.Spatial;
using actively.Models;

namespace actively.Controllers.API.Locations
{
    public class SearchController : ApiController
    {
        private readonly ILocationRepository locationRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public SearchController()
            : this(new LocationRepository())
        {
        }

        public SearchController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        // GET api/LocationAPI
        public IQueryable<Location> GetLocations()
        {
            
            return locationRepository.All;
        }

        // GET api/Default1/5
        public IQueryable<Location> GetLocation(double latitude, double longitude, string term, double distance)
        {
            DbGeography coordinate =  DbGeography.FromText(string.Format("POINT({0} {1})", latitude, longitude));
            IQueryable<Location> locations = locationRepository.All.Where(loc => loc.Coordinates.Distance(coordinate) <= distance);
            if (locations.Count() < 1)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }            
            return locations;
        }

        protected override void Dispose(bool disposing)
        {
            locationRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}