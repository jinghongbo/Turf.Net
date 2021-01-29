using NetTopologySuite.Geometries;
using System;

namespace Turf.Net
{
    public static partial class Turf
    {
        public static Geometry BboxClip(Geometry geometry, Envelope bbox)
        {
            throw new NotImplementedException();
        }


        public static LineString bezierSpline(LineString line, double resolution = 10000, double sharpnes = 0.85)
        {
            throw new NotImplementedException();
        }

        public static Geometry Buffer(Geometry geometry, double radius, Units units = Units.Kilometers, double steps = 64)
        {
            throw new NotImplementedException();
        }

        public static Polygon Circle(Point center, double radius, double steps = 64, Units units = Units.Kilometers)
        {
            throw new NotImplementedException();
        }

        public static Geometry Clone(Geometry geometry)
        {
            throw new NotImplementedException();
        }

        public static Polygon Concave(Point[] points, double maxEdge, Units units = Units.Kilometers)
        {
            throw new NotImplementedException();
        }
    }
}
