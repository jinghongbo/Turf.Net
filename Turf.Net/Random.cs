using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using System;
using System.Linq;

namespace Turf.Net
{
    public static partial class Turf
    {
        private static Random Random = new Random();

        private static double RandomDouble(double minValue, double maxValue)
        {
            return Random.NextDouble() * (maxValue - minValue) + minValue;
        }
        public static Coordinate RandomPosition(Envelope bbox = null)
        {
            if (bbox == null)
            {
                bbox = new Envelope(-180, 180, -90, 90);
            }

            var x = RandomDouble(bbox.MinX, bbox.MaxX);
            var y = RandomDouble(bbox.MinY, bbox.MaxX);
            return new Coordinate(x, y);
        }

        public static FeatureCollection RandomPoint(int count, Envelope bbox = null)
        {
            return FeatureCollection(Enumerable.Range(0, count).Select(_ => RandomPoint(bbox)).ToArray());
        }
        public static Feature RandomPoint(Envelope bbox = null)
        {
            return Point(RandomPosition(bbox));
        }



        public static FeatureCollection RandomLineString(int count, Envelope bbox = null, int numVertices = 10, double maxLength = 0.0001, double maxRotation = Math.PI / 8)
        {
            return FeatureCollection(Enumerable.Range(0, count).Select(_ => RandomLineString(bbox, numVertices, maxLength, maxRotation)).ToArray());
        }
        public static Feature RandomLineString(Envelope bbox = null, int numVertices = 10, double maxLength = 0.0001, double maxRotation = Math.PI / 8)
        {
            return LineString(Enumerable.Range(0, numVertices).Select(_ => RandomPosition(bbox)).ToArray());
        }


        public static FeatureCollection RandomPolygon(int count, Envelope bbox = null, int numVertices = 10, double maxRadialLength = 10)
        {
            return FeatureCollection(Enumerable.Range(0, count)
                .Select(_ => RandomPolygon(bbox, numVertices, maxRadialLength)).ToArray());
        }

        public static Feature RandomPolygon(Envelope bbox = null, int numVertices = 10, double maxRadialLength = 10)
        {
            var coordinates = Enumerable.Range(0, numVertices).Select(_ => RandomPosition(bbox)).ToList();
            coordinates.Add(coordinates[0]);
            return Polygon(coordinates.ToArray());
        }
    }
}
