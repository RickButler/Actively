using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using actively.Models;
using System.Data.Spatial;

namespace actively.Helpers
{
    /// <summary>
    /// Mirrors Googles Maps LatLng class with a DBGeometry object in the back end for .NET ease.
    /// </summary>
    public static class LatLngBoundsHelper
    {
        public static bool Contains(this LatLngBounds bounds, Point point)
        {            
            return bounds.Geometry.Contains(point.ToDBGeometry());           
        }

        public static bool Equals(this LatLngBounds bounds1, LatLngBounds bounds2)
        {
            return bounds1.Geometry.SpatialEquals(bounds2.Geometry);
        }

        /// <summary>
        /// Not Implemented
        /// </summary>
        /// <param name="bounds1"></param>
        /// <param name="bounds2"></param>
        public static void Extend(this LatLngBounds bounds1, LatLngBounds bounds2)
        {
            throw new NotImplementedException();            
        }

        public static Point GetCetner(this LatLngBounds bounds)
        {
            return new Point{ Latitude = bounds.Geometry.Centroid.XCoordinate, Longitude = bounds.Geometry.Centroid.YCoordinate};
        }

        public static bool Intersects(this LatLngBounds bounds1, LatLngBounds bounds2)
        {
            return bounds1.Geometry.Intersects(bounds2.Geometry);
        }

        public static bool IsEmpty(this LatLngBounds bounds)
        {
            return bounds.Geometry.IsEmpty;
        }

        public static string toString(this LatLngBounds bounds)
        {
            return bounds.Geometry.ToString();
        }

        public static LatLngBounds Union(this LatLngBounds bounds1, LatLngBounds bounds2)
        {                     
            return new LatLngBounds { Geometry = bounds1.Geometry.Union(bounds2.Geometry) };
        }     
        //getNorthEast()	LatLng	Returns the north-east corner of this bounds.
        //getSouthWest()	LatLng	Returns the south-west corner of this bounds.    
        //isEmpty()	boolean	Returns if the bounds are empty.
        //toSpan()	LatLng	Converts the given map bounds to a lat/lng span.    
        //toUrlValue(precision?:number)	string	Returns a string of the form "lat_lo,lng_lo,lat_hi,lng_hi" for this bounds, where "lo" corresponds to the southwest corner of the bounding box, while "hi" corresponds to the northeast corner of that box.    
    }
}