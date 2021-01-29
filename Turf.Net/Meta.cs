//using NetTopologySuite.Features;
//using NetTopologySuite.Geometries;
//using System;
//using System.Collections.Generic;

//namespace Turf.Net
//{
//    public static partial class Turf
//    {
//        public static Coordinate[] CoordAll(AllGeometry features)
//        {
//            var coords = new List<Coordinate>();
//            CoordEach(features, (currentCoord, coordIndex, featureIndex, multiFeatureIndex, geometryIndex) =>
//            {
//                coords.Add(currentCoord);
//                return true;
//            });

//            return coords.ToArray();
//        }

//        public static void CoordEach(Union<Feature, FeatureCollection, Geometry, GeometryCollection> geo, Func<Coordinate, int, int, int, int, bool> callback)
//        {
//            int featureIndex = 0, multiFeatureIndex = 0, geometryIndex = 0;
//            int coordIndex;
//            switch (geo.Value)
//            {
//                case FeatureCollection features:
//                    for (featureIndex = 0; featureIndex < features.Count; featureIndex++)
//                    {
//                        for (coordIndex = 0; coordIndex < features[featureIndex].Geometry.Coordinates.Length; coordIndex++)
//                        {
//                            var currentCoord = features[featureIndex].Geometry.Coordinates[coordIndex];
//                            if (!callback(currentCoord, coordIndex, featureIndex, multiFeatureIndex, geometryIndex)) break;
//                        }
//                    }
//                    break;
//                case Feature feature:
//                    for (coordIndex = 0; coordIndex < feature.Geometry.Coordinates.Length; coordIndex++)
//                    {
//                        var currentCoord = feature.Geometry.Coordinates[coordIndex];
//                        if (!callback(currentCoord, coordIndex, featureIndex, multiFeatureIndex, geometryIndex)) break;
//                    }
//                    break;
//                case GeometryCollection geometries:

//                    for (geometryIndex = 0; geometryIndex < geometries.Count; geometryIndex++)
//                    {
//                        for (coordIndex = 0; coordIndex < geometries[geometryIndex].Coordinates.Length; coordIndex++)
//                        {
//                            var currentCoord = geometries[geometryIndex].Coordinates[coordIndex];
//                            if (!callback(currentCoord, coordIndex, featureIndex, multiFeatureIndex, geometryIndex)) break;
//                        }
//                    }

//                    break;
//                case Geometry geometry:
//                    for (coordIndex = 0; coordIndex < geometry.Coordinates.Length; coordIndex++)
//                    {
//                        var currentCoord = geometry.Coordinates[coordIndex];
//                        if (!callback(currentCoord, coordIndex, featureIndex, multiFeatureIndex, geometryIndex)) break;
//                    }
//                    break;
//                    throw new Exception("类型错误");
//            }
//        }

//    }
//}
