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


namespace actively.Controllers.API.Places
{
    public class ZipController : ApiController
    {
        private readonly IPlaceRepository PlaceRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public ZipController()
            : this(new PlaceRepository())
        {
        }

        public ZipController(IPlaceRepository PlaceRepository)
        {
            this.PlaceRepository = PlaceRepository;
        }

        // GET api/PlaceAPI
        public IQueryable<Place> GetZip()
        {
            return PlaceRepository.All.OrderBy(z=>z.PostalCode);
        }


        // GET api/PlaceAPI/33066
        public IQueryable<Place> GetZip(string id)
        {
            IQueryable<Place> Place = PlaceRepository.All.Where( z => z.PostalCode.Contains(id) || z.PostalCode.Contains(id));
            if (Place.Count() < 1)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NoContent));
            }

            return Place;
        }

        // PUT api/PlaceAPI/5
        public HttpResponseMessage PutZip(int id, Place Place)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        // POST api/PlaceAPI
        public HttpResponseMessage PostZip(Place Place)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        // DELETE api/PlaceAPI/5
        public HttpResponseMessage DeleteZip(int id)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        protected override void Dispose(bool disposing)
        {
            PlaceRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}