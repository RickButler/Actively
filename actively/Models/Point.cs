using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Spatial;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace actively.Models
{
    public class Point
    {        
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}