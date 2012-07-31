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
        [Key, Newtonsoft.Json.JsonIgnore, System.Xml.Serialization.XmlIgnore]  
        public int Id { get; set; }
        
        [StringLength(128)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public Position Position
        {
            get
            {
                if (Coordinates != null)
                    return new Position { Latitude = this.Coordinates.Latitude, Longitude = this.Coordinates.Longitude };
                return new Position();
            }
            set
            {      
                Coordinates = value.ToDBGeography();                    
            }
        }

        [Newtonsoft.Json.JsonIgnore, System.Xml.Serialization.XmlIgnore]
        public DbGeography Coordinates { get; set; }
            
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