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
        public Point Position 
        { 
            get
            {
                if (Coordinates != null)
                    return new Point { Latitude = this.Coordinates.XCoordinate, Longitude = this.Coordinates.YCoordinate };
                return new Point();
            } 
            set 
            {

                Coordinates = value.ToDBGeometry();
            } 
        }

        [Newtonsoft.Json.JsonIgnore, System.Xml.Serialization.XmlIgnore]
        public DbGeometry Coordinates { get; set; }

        public int Accuracy { get; set; }
    }
}