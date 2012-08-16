using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Spatial;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using actively.Helpers;

namespace actively.Models
{
    public class Location
    {
        [Key, Newtonsoft.Json.JsonIgnore, System.Xml.Serialization.XmlIgnore]  
        public int Id { get; set; }
        
        [StringLength(128)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public Point Position
        {
            get
            {
                if (Coordinates != null)
                    return new Point { Latitude = this.Coordinates.Centroid.XCoordinate, Longitude = this.Coordinates.Centroid.YCoordinate };
                return new Point();
            }
            set
            {      
                Coordinates = value.ToDBGeometry();                    
            }
        }

        [Newtonsoft.Json.JsonIgnore, System.Xml.Serialization.XmlIgnore]
        public DbGeometry Coordinates { get; set; }
            
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