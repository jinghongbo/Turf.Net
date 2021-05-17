using NetTopologySuite.Geometries;
using System;

namespace Turf.Net
{
    public static partial class Turf
    {
        private const int RADIUS = 6378137;

        public static Point Along(LineString line, double distance, Units units = Units.Kilometers)
        {
            var coords = line.Coordinates;
            var travelled = 0d;
            for (var i = 0; i < coords.Length; i++)
            {
                if (distance >= travelled && i == coords.Length - 1)
                {
                    break;
                }
                else if (travelled >= distance)
                {
                    var overshot = distance - travelled;
                    if (overshot == 0)
                    {
                        return new Point(coords[i]);
                    }
                    else
                    {
                        var direction = Bearing(coords[i], coords[i - 1]) - 180;
                        var interpolated = Destination(
                          coords[i],
                          overshot,
                          direction,
                          units
                        );
                        return interpolated;
                    }
                }
                else
                {
                    travelled += Distance(coords[i], coords[i + 1], units);
                }
            }
            return new Point(coords[coords.Length - 1]);
        }
        public static double Area(Geometry geometry)
        {
            switch (geometry.OgcGeometryType)
            {
                case OgcGeometryType.Polygon:
                    return PolygonArea((Polygon)geometry);
                default:
                    return 0;
            }
        }
        public static Envelope Bbox(Geometry geometry)
        {
            throw new NotImplementedException();
        }
        public static Polygon BboxPolygon(Envelope bbox)
        {
            throw new NotImplementedException();

        }
        public static double Bearing(Coordinate start, Coordinate end, bool final = false)
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
        public static Point Destination(Coordinate origin, double distance, double bearing, Units units = Units.Kilometers)
        {
            var coordinates1 = origin;
            var longitude1 = DegreesToRadians(coordinates1[0]);
            var latitude1 = DegreesToRadians(coordinates1[1]);
            var bearingRad = DegreesToRadians(bearing);
            var radians = LengthToRadians(distance, units);

            // Main
            var latitude2 = Math.Asin(
               Math.Sin(latitude1) * Math.Cos(radians) +
                 Math.Cos(latitude1) * Math.Sin(radians) * Math.Cos(bearingRad)
             );
            var longitude2 =
              longitude1 +
              Math.Atan2(
                Math.Sin(bearingRad) * Math.Sin(radians) * Math.Cos(latitude1),
                Math.Cos(radians) - Math.Sin(latitude1) * Math.Sin(latitude2)
              );
            var lng = RadiansToDegrees(longitude2);
            var lat = RadiansToDegrees(latitude2);

            return new Point(lng, lat);
        }
        public static double Distance(Coordinate from, Coordinate to, Units units = Units.Kilometers)
        {
            var coordinates1 = from;
            var coordinates2 = to;
            var dLat = DegreesToRadians(coordinates2[1] - coordinates1[1]);
            var dLon = DegreesToRadians(coordinates2[0] - coordinates1[0]);
            var lat1 = DegreesToRadians(coordinates1[1]);
            var lat2 = DegreesToRadians(coordinates2[1]);

            var a =
              Math.Pow(Math.Sin(dLat / 2), 2) +
              Math.Pow(Math.Sin(dLon / 2), 2) * Math.Cos(lat1) * Math.Cos(lat2);

            return RadiansToLength(
              2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)),
             units
            );

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


        #region 私有方法
        private static double PolygonArea(Polygon polygon)
        {
            double total = 0;
            if (polygon.Coordinates != null && polygon.Coordinates.Length > 0)
            {
                total += Math.Abs(RingArea(polygon.Coordinates));
                foreach (LinearRing hole in polygon.Holes)
                {
                    total -= Math.Abs(RingArea(hole.Coordinates));
                }
            }
            return total;
        }

        private static double RingArea(Coordinate[] coords)
        {
            Coordinate p1;
            Coordinate p2;
            Coordinate p3;
            int lowerIndex;
            int middleIndex;
            int upperIndex;
            int i;
            double total = 0;
            var coordsLength = coords.Length;

            if (coordsLength > 2)
            {
                for (i = 0; i < coordsLength; i++)
                {
                    if (i == coordsLength - 2)
                    {
                        // i = N-2
                        lowerIndex = coordsLength - 2;
                        middleIndex = coordsLength - 1;
                        upperIndex = 0;
                    }
                    else if (i == coordsLength - 1)
                    {
                        // i = N-1
                        lowerIndex = coordsLength - 1;
                        middleIndex = 0;
                        upperIndex = 1;
                    }
                    else
                    {
                        // i = 0 to N-3
                        lowerIndex = i;
                        middleIndex = i + 1;
                        upperIndex = i + 2;
                    }
                    p1 = coords[lowerIndex];
                    p2 = coords[middleIndex];
                    p3 = coords[upperIndex];
                    total += (Rad(p3[0]) - Rad(p1[0])) * Math.Sin(Rad(p2[1]));
                }

                total = (total * RADIUS * RADIUS) / 2;
            }
            return total;
        }

        private static double Rad(double num)
        {
            return (num * Math.PI) / 180;
        }
        #endregion

    }
}
