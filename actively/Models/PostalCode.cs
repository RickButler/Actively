using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Spatial;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace actively.Models
{
    public class PostalCode
    {
        [Key]
        public int Id { get; set; }

        [StringLength(16)]
        public string Postal { get; set; }

        [StringLength(128)]
        public string City { get; set; }

        [StringLength(32)]
        public string State { get; set; }        

        public double Lat { get; set; }

        public double Long { get; set; }

        public int TimeZone { get; set; }

        public int DST { get; set; }
    }
}