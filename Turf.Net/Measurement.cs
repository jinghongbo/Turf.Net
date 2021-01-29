using NetTopologySuite.Geometries;
using System;

namespace Turf.Net
{
    public static partial class Turf
    {
        public static Point Along(LineString line, double distance, Units units = Units.Kilometers)
        {
            throw new NotImplementedException();
        }
        public static double Area(Geometry geometry)
        {
            throw new NotImplementedException();
        }
        public static Envelope Bbox(Geometry geometry)
        {
            throw new NotImplementedException();
        }
        public static Polygon BboxPolygon(Envelope bbox)
        {
            throw new NotImplementedException();

        }
        public static double Bearing(Point start, Point end, bool final = false)
        {
            throw new NotImplementedException();
        }
        public static Point Center(Geometry geometry)
        {
            throw new NotImplementedException();
        }
        public static Point CenterOfMass(Geometry geometry)
        {
            throw new NotImplementedException();
        }
        public static Point Centroid(Geometry geometry)
        {
            throw new NotImplementedException();
        }
        public static Point Destination(Point origin, double distance, double bearing, Units units = Units.Kilometers)
        {
            throw new NotImplementedException();
        }
        public static double Distance(Point from, Point to, Units units = Units.Kilometers)
        {
            //var dLat = DegreesToRadians(to[1] - from[1]);
            //var dLon = DegreesToRadians(to[0] - from[0]);
            //var lat1 = DegreesToRadians(from[1]);
            //var lat2 = DegreesToRadians(to[1]);

            //var a =
            //  Math.Pow(Math.Sin(dLat / 2), 2) +
            //  Math.Pow(Math.Sin(dLon / 2), 2) * Math.Cos(lat1) * Math.Cos(lat2);

            //return RadiansToLength(
            //  2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)),
            //  units
            //);

            throw new NotImplementedException();
        }
        public static Polygon Envelope(Geometry geometry)
        {
            throw new NotImplementedException();
        }
        public static double Length(Geometry geometry, Units units = Units.Kilometers)
        {
            throw new NotImplementedException();
        }
        public static double Length(GeometryCollection geometries, Units units = Units.Kilometers)
        {
            throw new NotImplementedException();
        }
        public static Point Midpoint(Point point1, Point point2)
        {
            throw new NotImplementedException();
        }
        public static Point PointOnFeature(Geometry geometry)
        {
            throw new NotImplementedException();
        }
        public static GeometryCollection PolygonTangents(Point point, Polygon polygon)
        {
            throw new NotImplementedException();
        }
        public static double PointToLineDistance(Point point, LineString line, Units units = Units.Kilometers, bool mercator = false)
        {
            throw new NotImplementedException();
        }
        public static double RhumbBearing(Point start, Point end, bool final = false)
        {
            throw new NotImplementedException();
        }
        public static Geometry RhumbDestination(Point origin, double distance, double bearing, Units units = Units.Kilometers)
        {
            throw new NotImplementedException();
        }
        public static double RhumbDistance(Point from, Point to, string units = "kilometers")
        {
            throw new NotImplementedException();
        }
        public static Envelope Square(Envelope bbox)
        {
            throw new NotImplementedException();
        }
        public static Geometry GreatCircle(Point start, Point end, double npoints = 100, double offset = 10)
        {
            throw new NotImplementedException();
        }


    }
}
