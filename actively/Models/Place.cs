using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Spatial;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace actively.Models
{
    public class Place
    {
        [Key, Newtonsoft.Json.JsonIgnore, System.Xml.Serialization.XmlIgnore]
        public int Id { get; set; }

        [StringLength(2)]
        public string CountryCode { get; set; }

        [StringLength(20)]
        public string PostalCode {get; set;}

        [StringLength(180)]
        public string PlaceName { get; set; }

        [StringLength(100)]
        public string StateName { get; set; }

        [StringLength(20)]
        public string StateCode { get; set; }

        [StringLength(100)]
        public string ProvinceName { get; set; }

        [StringLength(20)]
        public string ProvinceCode { get; set; }

        [StringLength(100)]
        public string SubDivisionName { get; set; }

        [StringLength(20)]
        public string SubDivisionCode { get; set; }

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

        public int Accuracy { get; set; }
    }
}