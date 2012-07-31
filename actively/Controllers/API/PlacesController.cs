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


namespace actively.Controllers.API
{
    public class PlacesController : ApiController
    {
        private readonly IPlaceRepository PlaceRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public PlacesController()
            : this(new PlaceRepository())
        {
        }

        public PlacesController(IPlaceRepository PlaceRepository)
        {
            this.PlaceRepository = PlaceRepository;
        }

        // GET api/PlaceAPI
        public IQueryable<Place> GetPlaces()
        {
            return PlaceRepository.All;
        }


        // GET api/PlaceAPI/33066
        public Place GetPlace(int id)
        {
            Place Place = PlaceRepository.Find(id);
            if (Place == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Place;
        }

        // PUT api/PlaceAPI/5
        public HttpResponseMessage PutPlace(int id, Place Place)
        {
            if (ModelState.IsValid && id == Place.Id)
            {
                try
                {
                    PlaceRepository.InsertOrUpdate(Place);
                    PlaceRepository.Save();
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, Place);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/PlaceAPI
        public HttpResponseMessage PostPlace(Place Place)
        {
            if (ModelState.IsValid)
            {
                PlaceRepository.InsertOrUpdate(Place);
                PlaceRepository.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Place);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Place.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/PlaceAPI/5
        public HttpResponseMessage DeletePlace(int id)
        {
            Place Place = PlaceRepository.Find(id);
            if (Place == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            PlaceRepository.Delete(id);

            try
            {
                PlaceRepository.Save();
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Place);
        }

        protected override void Dispose(bool disposing)
        {
            PlaceRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}