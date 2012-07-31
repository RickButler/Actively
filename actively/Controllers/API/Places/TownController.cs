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
    public class TownController : ApiController
    {
        private readonly IPlaceRepository PlaceRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public TownController()
            : this(new PlaceRepository())
        {
        }

        public TownController(IPlaceRepository PlaceRepository)
        {
            this.PlaceRepository = PlaceRepository;
        }

        // GET api/PlaceAPI
        public IQueryable<Place> GetTown()
        {
            return PlaceRepository.All.OrderBy(t=>t.SubDivisionName);
        }


        // GET api/PlaceAPI/33066
        public IQueryable<Place> GetTown(string id)
        {
            IQueryable<Place> Place = PlaceRepository.All.Where( t => t.SubDivisionName.Contains(id) || t.SubDivisionCode.Contains(id));
            if (Place.Count() < 1)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NoContent));
            }

            return Place;
        }

        // PUT api/PlaceAPI/5
        public HttpResponseMessage PutTown(int id, Place Place)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        // POST api/PlaceAPI
        public HttpResponseMessage PostTown(Place Place)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        // DELETE api/PlaceAPI/5
        public HttpResponseMessage DeleteTown(int id)
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