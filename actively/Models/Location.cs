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
            public string Name { get; set; }
            [Newtonsoft.Json.JsonIgnore, System.Xml.Serialization.XmlIgnore]
            public DbGeography Coordinates {get; set;}
            [System.ComponentModel.DataAnnotations.Schema.NotMapped]
            public string Point { get { return Coordinates == null ? string.Empty : Coordinates.AsText(); } set { Coordinates = DbGeography.PointFromText(value, DbGeography.DefaultCoordinateSystemId); } }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Postal { get; set; }
            public string Type { get; set; }
            public string Keywords { get; set; }        
    }
}