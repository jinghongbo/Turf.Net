using NetTopologySuite;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Turf.Net
{
    public static partial class Turf
    {
        public class Coordinates
        {
            internal Coordinate A1 { get; set; }
            internal Coordinate[] A2 { get; set; }
            internal Coordinate[][] A3 { get; set; }
            internal Coordinate[][][] A4 { get; set; }



            public static implicit operator Coordinates(Coordinate coordinates)
            {
                return new Coordinates() { A1 = coordinates };
            }


            public static implicit operator Coordinates(Coordinate[] coordinates)
            {
                return new Coordinates() { A2 = coordinates };
            }
            public static implicit operator Coordinates(Coordinate[][] coordinates)
            {
                return new Coordinates() { A3 = coordinates };
            }
            public static implicit operator Coordinates(Coordinate[][][] coordinates)
            {
                return new Coordinates() { A4 = coordinates };
            }

            public static implicit operator Coordinate(Coordinates coordinates)
            {
                return coordinates.A1;
            }
            public static implicit operator Coordinate[](Coordinates coordinates)
            {
                return coordinates.A2;
            }
            public static implicit operator Coordinate[][](Coordinates coordinates)
            {
                return coordinates.A3;
            }
            public static implicit operator Coordinate[][][](Coordinates coordinates)
            {
                return coordinates.A4;
            }
        }

        private static GeometryFactory GeometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(4326);

        public static readonly double EarthRadius = 6371008.8;

        public static readonly Dictionary<string, double> Factors = new Dictionary<string, double>()
        {
            {"centimeters", EarthRadius * 100},
            {"centimetres", EarthRadius * 100},
            {"degrees", EarthRadius / 111325},
            {"feet", EarthRadius * 3.28084},
            {"inches", EarthRadius * 39.370},
            {"kilometers", EarthRadius / 1000},
            {"kilometres", EarthRadius / 1000},
            {"meters", EarthRadius},
            {"metres", EarthRadius},
            {"miles", EarthRadius / 1609.344},
            {"millimeters", EarthRadius * 1000},
            {"millimetres", EarthRadius * 1000},
            {"nauticalmiles", EarthRadius / 1852},
            {"radians", 1},
            {"yards", EarthRadius / 1.0936},
        };

        public static readonly Dictionary<string, double> AreaFactors = new Dictionary<string, double>() {
           {"acres", 0.000247105},
           {"centimeters", 10000},
           {"centimetres", 10000},
           {"feet", 10.763910417},
           {"inches", 1550.003100006},
           {"kilometers", 0.000001},
           {"kilometres", 0.000001},
           {"meters", 1},
           {"metres", 1},
           {"miles", 3.86e-7},
           {"millimeters", 1000000},
           {"millimetres", 1000000},
            { "yards", 1.195990046},
        };

        public static FeatureCollection FeatureCollection(Feature[] features, Envelope bbox = null, object id = null)
        {
            var fc = new FeatureCollection() { BoundingBox = bbox };
            foreach (var feature in features)
            {
                fc.Add(feature);
            }
            return fc;
        }
        public static Feature Feature(Geometry geom, AttributesTable properties = null, Envelope bbox = null)
        {
            var feat = new Feature();
            if (bbox != null) { feat.BoundingBox = bbox; }
            feat.Attributes = properties ?? new AttributesTable();
            feat.Geometry = geom;
            return feat;
        }

        public static Geometry Geometry(string type, Coordinates coordinates)
        {
            switch (type)
            {
                case "Point": return Point(coordinates).Geometry;
                case "LineString": return LineString(coordinates).Geometry;
                case "Polygon": return Polygon(coordinates).Geometry;
                case "MultiPoint": return MultiPoint(coordinates).Geometry;
                case "MultiLineString": return MultiLineString(coordinates).Geometry;
                case "MultiPolygon": return MultiPolygon(coordinates).Geometry;
                default: throw new Exception(type + " is ivalid");

            }
        }
        public static Feature GeometryCollection(Geometry[] geometries, AttributesTable properties = null, Envelope bbox = null, object id = null)
        {
            var geom = GeometryFactory.CreateGeometryCollection(geometries);
            return Feature(geom, properties, bbox);
        }

        public static Feature LineString(Coordinate[] coordinates, AttributesTable properties = null, Envelope bbox = null)
        {
            var geom = GeometryFactory.CreateLineString(coordinates);
            return Feature(geom, properties, bbox);
        }

        public static FeatureCollection LineStrings(Coordinate[][] coordinates, AttributesTable properties = null, Envelope bbox = null)
        {
            return FeatureCollection(coordinates.Select(x => LineString(x, properties, bbox)).ToArray());
        }
        public static Feature MultiLineString(Coordinate[][] coordinates, AttributesTable properties = null, Envelope bbox = null)
        {
            var geom = GeometryFactory.CreateMultiLineString(coordinates.Select(c => GeometryFactory.CreateLineString(c)).ToArray());
            return Feature(geom, properties, bbox);
        }

        public static Feature MultiPoint(Coordinate[] coordinates, AttributesTable properties = null, Envelope bbox = null)
        {
            var geom = GeometryFactory.CreateMultiPoint(coordinates.Select(x => GeometryFactory.CreatePoint(x)).ToArray());
            return Feature(geom, properties, bbox);
        }
        public static Feature MultiPolygon(Coordinate[][] coordinates, AttributesTable properties = null, Envelope bbox = null)
        {
            var geom = GeometryFactory.CreateMultiPolygon(coordinates.Select(x => GeometryFactory.CreatePolygon(x)).ToArray());
            return Feature(geom, properties, bbox);
        }
        public static Feature Point(Coordinate coordinates, AttributesTable properties = null, Envelope bbox = null)
        {
            var geom = GeometryFactory.CreatePoint(coordinates);
            return Feature(geom, properties, bbox);
        }

        public static FeatureCollection Points(Coordinate[] coordinates, AttributesTable properties = null, Envelope bbox = null)
        {
            return FeatureCollection(coordinates.Select(x => Point(x, properties, bbox)).ToArray());
        }
        public static Feature Polygon(Coordinate[] coordinates, AttributesTable properties = null, Envelope bbox = null)
        {
            var geom = GeometryFactory.CreatePolygon(coordinates);
            return Feature(geom, properties, bbox);
        }
        public static FeatureCollection Polygons(Coordinate[][] coordinates, AttributesTable properties = null, Envelope bbox = null)
        {
            return FeatureCollection(coordinates.Select(x => Polygon(x, properties, bbox)).ToArray());
        }

        public static double Round(double num, int precision = 0)
        {
            return Math.Round(num, precision);
        }

        public static double RadiansToLength(double radians, string units = "kilometers")
        {
            if (!Factors.ContainsKey(units)) { throw new Exception(units + " units is invalid"); }
            var factor = Factors[units];
            return radians * factor;
        }
        public static double LengthToRadians(double distance, string units = "kilometers")
        {
            if (!Factors.ContainsKey(units)) { throw new Exception(units + " units is invalid"); }
            var factor = Factors[units];
            return distance / factor;
        }
        public static double LengthToDegrees(double distance, string units = "kilometers")
        {
            return RadiansToDegrees(LengthToRadians(distance, units));
        }

        public static double BearingToAzimuth(double bearing)
        {
            var angle = bearing % 360;
            if (angle < 0) { angle += 360; }
            return angle;
        }
        public static double RadiansToDegrees(double radians)
        {
            var degrees = radians % (2 * Math.PI);
            return degrees * 180 / Math.PI;
        }

        public static double DegreesToRadians(double degrees)
        {
            var radians = degrees % 360;
            return radians * Math.PI / 180;
        }

        public static double ConvertLength(double length, string originalUnit = "kilometers", string finalUnit = "kilometers")
        {
            if (!(length >= 0)) { throw new Exception("length must be a positive number"); }
            return RadiansToLength(LengthToRadians(length, originalUnit), finalUnit);
        }
        public static double ConvertArea(double area, string originalUnit = "kilometers", string finalUnit = "kilometers")
        {
            if (!AreaFactors.ContainsKey(originalUnit)) { throw new Exception("invalid original units"); }

            var startFactor = AreaFactors[originalUnit];
            if (!AreaFactors.ContainsKey(finalUnit)) { throw new Exception("invalid final units"); }
            var finalFactor = AreaFactors[finalUnit];

            return (area / startFactor) * finalFactor;
        }

    }

}
