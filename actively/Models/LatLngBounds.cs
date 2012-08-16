using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Spatial;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace actively.Models
{
    public class LatLngBounds
    {
        public Point NorthEast { get; set; }
        public Point SouthWest { get; set; }
        public DbGeometry Geometry { get; set; }
    }
}