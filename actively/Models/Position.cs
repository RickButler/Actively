using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Spatial;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace actively.Models
{
    public class Position
    {        
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DbGeography ToDBGeography()
        {
            try
            {
                return DbGeography.FromText(string.Format("POINT({0} {1})", this.Longitude, this.Latitude), DbGeography.DefaultCoordinateSystemId);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
    }
}