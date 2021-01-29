using NetTopologySuite.Geometries;
using System;
using System.Linq;

namespace Turf.Net
{
    public static partial class Turf
    {
        private static readonly Random Random = new Random();

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
            double x = RandomDouble(bbox.MinX, bbox.MaxX);
            double y = RandomDouble(bbox.MinY, bbox.MaxX);
            return new Coordinate(x, y);
        }

        public static Point[] RandomPoint(int count, Envelope bbox = null)
        {
            return Enumerable.Range(0, count).Select(_ => new Point(RandomPosition(bbox))).ToArray();
        }

        public static LineString[] RandomLineString(int count, Envelope bbox = null, int numVertices = 10, double maxLength = 0.0001, double maxRotation = Math.PI / 8)
        {

            throw new NotImplementedException();
        }

        public static Polygon[] RandomPolygon(int count, Envelope bbox = null, int numVertices = 10, double maxRadialLength = 10)
        {
            throw new NotImplementedException();
        }
    }
}
