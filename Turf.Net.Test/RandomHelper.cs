using NetTopologySuite.Geometries;
using NetTopologySuite.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Turf.Net.Test
{
    public static class RandomHelper
    {
        private static readonly Random random = new Random();

        public static Coordinate RandomCoordinate()
        {
            var x = random.Next(-180, 180);
            var y = random.Next(-90, 90);
            return new Coordinate(x, y);
        }

        public static Coordinate[] RandomCoordinates(bool isRing = false)
        {
            var count = random.Next(3, 10);

            List<Coordinate> coordinates = new List<Coordinate>();
            for (int i = 0; i < count; i++)
            {
                var coordinate = RandomCoordinate();
                coordinates.Add(coordinate);
            }
            if (isRing)
            {
                coordinates.Add(coordinates[0]);
            }

            return coordinates.ToArray();

        }

    }
}
