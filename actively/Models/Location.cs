using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Spatial;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace actively.Models
{
    public class Location
    {               
        public int Id { get; set; }
        
        [StringLength(128)]
        public string Name { get; set; }
        
        [Newtonsoft.Json.JsonIgnore, System.Xml.Serialization.XmlIgnore]
        public DbGeography Coordinates {get; set;}
        
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string Point { get { return Coordinates == null ? string.Empty : Coordinates.AsText(); } set { Coordinates = DbGeography.PointFromText(value, DbGeography.DefaultCoordinateSystemId); } }
            
        [StringLength(128)]
        public string Address { get; set; }

        [StringLength(128)]
        public string City { get; set; }

        [StringLength(32)]
        public string State { get; set; }

        [StringLength(16)]
        public string Postal { get; set; }

        [StringLength(256)]
        public string Type { get; set; }
        
        [StringLength(512)]
        public string Keywords { get; set; }        
    }
}