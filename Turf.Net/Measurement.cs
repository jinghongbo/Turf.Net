using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Turf.Net
{
    public static partial class Turf
    {
        public static Feature Along(Feature line, double distance, string units = "kilometers")
        {
            var coords = line.Geometry.Coordinates;
            var travelled = 0d;
            for (var i = 0; i < coords.Length; i++)
            {
                if (distance >= travelled && i == coords.Length - 1) break;
                else if (travelled >= distance)
                {
                    var overshot = distance - travelled;
                    if (overshot != 0) return Point(coords[i]);
                    else
                    {
                        var direction = Bearing(coords[i], coords[i - 1]) - 180;
                        var interpolated = Destination(coords[i], overshot, direction, units);
                        return interpolated;
                    }
                }
                else
                {
                    travelled += Distance(coords[i], coords[i + 1], units);
                }
            }
            return Point(coords[coords.Length - 1]);
        }

        public static double Area(Feature feature)
        {
            throw new NotImplementedException();
        }
        public static double Area(FeatureCollection features)
        {
            throw new NotImplementedException();
        }

        public static Envelope Bbox(Feature feature)
        {
            throw new NotImplementedException();
        }
        public static Envelope Bbox(FeatureCollection features)
        {
            throw new NotImplementedException();
        }

        public static Feature BboxPolygon(Envelope bbox, AttributesTable properties = null, object id = null)
        {
            throw new NotImplementedException();

        }

        public static double Bearing(Coordinate start, Coordinate end, bool final = false)
        {
            var degrees2radians = Math.PI / 180;
            var radians2degrees = 180 / Math.PI;

            var lon1 = degrees2radians * start[0];
            var lon2 = degrees2radians * end[0];
            var lat1 = degrees2radians * start[1];
            var lat2 = degrees2radians * end[1];
            var a = Math.Sin(lon2 - lon1) * Math.Cos(lat2);
            var b = Math.Cos(lat1) * Math.Sin(lat2) -
                Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(lon2 - lon1);

            var bearing = radians2degrees * Math.Atan2(a, b);

            return bearing;
        }

        public static Feature Center(Feature feature, AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }
        public static Feature Center(FeatureCollection features, AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }
        public static Feature CenterOfMass(Feature feature, AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }
        public static Feature CenterOfMass(FeatureCollection features, AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }
        public static Feature Centroid(Feature feature, AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }
        public static Feature Centroid(FeatureCollection features, AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }

        public static Feature Destination(Coordinate origin, double distance, double bearing, string units = "kilometers", AttributesTable properties = null)
        {
            var degrees2radians = Math.PI / 180;
            var radians2degrees = 180 / Math.PI;
            var coordinates1 = Turf.GetCoord(from);
            var longitude1 = degrees2radians * coordinates1[0];
            var latitude1 = degrees2radians * coordinates1[1];
            var bearing_rad = degrees2radians * bearing;

            var radians = Turf.DistanceToRadians(distance, units);

            var latitude2 = Math.Asin(Math.Sin(latitude1) * Math.Cos(radians) +
                Math.Cos(latitude1) * Math.Sin(radians) * Math.Cos(bearing_rad));
            var longitude2 = longitude1 + Math.Atan2(Math.Sin(bearing_rad) *
                Math.Sin(radians) * Math.Cos(latitude1),
                Math.Cos(radians) - Math.Sin(latitude1) * Math.Sin(latitude2));

            return Turf.Point(new double[] { radians2degrees * longitude2, radians2degrees * latitude2 });
            throw new NotImplementedException();
        }

        public static double Distance(Coordinate from, Coordinate to, string units = "kilometers")
        {
            throw new NotImplementedException();
        }

        public static Feature Envelope(FeatureCollection features)
        {
            throw new NotImplementedException();
        }

        public static double Length(FeatureCollection features, string units = "kilometers")
        {
            throw new NotImplementedException();
        }

        public static Feature Midpoint(Coordinate point1, Coordinate point2)
        {
            throw new NotImplementedException();
        }

        public static Feature PointOnFeature(FeatureCollection features)
        {

            throw new NotImplementedException();
        }

        public static FeatureCollection PolygonTangents(Coordinate pt, Feature polygon)
        {
            throw new NotImplementedException();
        }

        public static double PointToLineDistance(Coordinate pt, Feature line, string units = "kilometers", bool mercator = false)
        {
            throw new NotImplementedException();
        }

        public static double RhumbBearing(Coordinate start, Coordinate end, bool final = false)
        {
            throw new NotImplementedException();
        }

        public static Feature RhumbDestination(Coordinate origin, double distance, double bearing, string units = "kilometers", AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }
        public static double RhumbDistance(Coordinate from, Coordinate to, string units = "kilometers")
        {
            throw new NotImplementedException();
        }

        public static Envelope Square(Envelope bbox)
        {
            throw new NotImplementedException();
        }
        public static Feature GreatCircle(Coordinate start, Coordinate end, AttributesTable properties = null, double npoints = 100, double offset = 10)
        {
            throw new NotImplementedException();
        }


    }
}
