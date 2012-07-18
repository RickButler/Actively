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


namespace actively2.Controllers.API
{
    public class LocationController : ApiController
    {
        private readonly ILocationRepository locationRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public LocationController()
            : this(new LocationRepository())
        {
        }

        public LocationController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        // GET api/LocationAPI
        public IQueryable<Location> GetLocations()
        {
            return locationRepository.All;
        }

        // GET api/LocationAPI
        public IQueryable<Location> GetLocations(double Lat, double Long, double Distance)
        {            
            
            DbGeography point = DbGeography.PointFromText( string.Format("POINT ({0} {1})",Lat,Long), DbGeography.DefaultCoordinateSystemId );            
            point.AsText();
            return locationRepository.All.Where(location => location.Coordinates.Distance(point) <= Distance);
        }

        // GET api/LocationAPI/5
        public Location GetLocation(int id)
        {
            Location location = locationRepository.Find(id);
            if (location == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return location;
        }

        // PUT api/LocationAPI/5
        public HttpResponseMessage PutLocation(int id, Location location)
        {
            if (ModelState.IsValid && id == location.Id)
            {
                try
                {
                    locationRepository.InsertOrUpdate(location);
                    locationRepository.Save();
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, location);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/LocationAPI
        public HttpResponseMessage PostLocation(Location location)
        {
            if (ModelState.IsValid)
            {
                locationRepository.InsertOrUpdate(location);
                locationRepository.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, location);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = location.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/LocationAPI/5
        public HttpResponseMessage DeleteLocation(int id)
        {
            Location location = locationRepository.Find(id);
            if (location == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            locationRepository.Delete(id);

            try
            {
                locationRepository.Save();
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, location);
        }

        protected override void Dispose(bool disposing)
        {
            locationRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}