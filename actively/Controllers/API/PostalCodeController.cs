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
    public class PostalCodeController : ApiController
    {
        private readonly IPostalCodeRepository PostalCodeRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public PostalCodeController()
            : this(new PostalCodeRepository())
        {
        }

        public PostalCodeController(IPostalCodeRepository PostalCodeRepository)
        {
            this.PostalCodeRepository = PostalCodeRepository;
        }

        // GET api/PostalCodeAPI
        public IQueryable<PostalCode> GetPostalCodes()
        {
            return PostalCodeRepository.All;
        }


        // GET api/PostalCodeAPI/33066
        public PostalCode GetPostalCode(string id)
        {
            PostalCode PostalCode = PostalCodeRepository.All.FirstOrDefault(pCode => pCode.Postal.StartsWith(id));
            if (PostalCode == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return PostalCode;
        }

        // PUT api/PostalCodeAPI/5
        public HttpResponseMessage PutPostalCode(int id, PostalCode PostalCode)
        {
            if (ModelState.IsValid && id == PostalCode.Id)
            {
                try
                {
                    PostalCodeRepository.InsertOrUpdate(PostalCode);
                    PostalCodeRepository.Save();
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, PostalCode);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/PostalCodeAPI
        public HttpResponseMessage PostPostalCode(PostalCode PostalCode)
        {
            if (ModelState.IsValid)
            {
                PostalCodeRepository.InsertOrUpdate(PostalCode);
                PostalCodeRepository.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, PostalCode);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = PostalCode.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/PostalCodeAPI/5
        public HttpResponseMessage DeletePostalCode(int id)
        {
            PostalCode PostalCode = PostalCodeRepository.Find(id);
            if (PostalCode == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            PostalCodeRepository.Delete(id);

            try
            {
                PostalCodeRepository.Save();
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, PostalCode);
        }

        protected override void Dispose(bool disposing)
        {
            PostalCodeRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}