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
        public static Coordinate[] CoordAll(FeatureCollection features)
        {
            return features.SelectMany(x => x.Geometry.Coordinates).ToArray();
        }

        public static void CoordEach(FeatureCollection features, Action<Coordinate, int, Feature, int> callback)
        {
            for (int featureIndex = 0; featureIndex < features.Count; featureIndex++)
            {
                var currentFeature = (Feature)features[featureIndex];
                for (int coordIndex = 0; coordIndex < currentFeature.Geometry.Coordinates.Length; coordIndex++)
                {
                    var currentCoord = currentFeature.Geometry.Coordinates[coordIndex];

                    callback(currentCoord, coordIndex, currentFeature, featureIndex);
                }
            }
        }
    }
}
