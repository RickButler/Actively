using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using actively.Models;
using System.Data.Spatial;

namespace actively.Helpers
{
    public static class PointHelper
    {
        public static DbGeography ToDBGeography(this Point point)
        {
            try
            {
                return DbGeography.FromText(string.Format("POINT({0} {1})", point.Longitude, point.Latitude), DbGeography.DefaultCoordinateSystemId);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
        public static DbGeometry ToDBGeometry(this Point point)
        {
            try
            {
                return DbGeometry.FromText(string.Format("POINT({0} {1})", point.Longitude, point.Latitude), DbGeometry.DefaultCoordinateSystemId);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
    }
}