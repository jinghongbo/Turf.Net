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
        private static GeometryFactory GeometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(4326);
        public static FeatureCollection FeatureCollection(Feature[] features, Envelope bbox = null, object id = null)
        {
            var collection = new FeatureCollection() { BoundingBox = bbox };
            foreach (var feature in features)
            {
                collection.Add(feature);
            }
            return collection;

        }
        public static Feature Feature(Geometry geometry, AttributesTable properties = null, Envelope bbox = null, object id = null)
        {
            return new Feature()
            {
                Geometry = geometry,
                Attributes = properties,
                BoundingBox = bbox
            };
        }

        public static Feature GeometryCollection(Geometry[] geometries, AttributesTable properties = null, Envelope bbox = null, object id = null)
        {
            return new Feature()
            {
                Geometry = GeometryFactory.CreateGeometryCollection(geometries),
                Attributes = properties,
                BoundingBox = bbox
            };
        }

        public static Feature LineString(Coordinate[] coordinates, AttributesTable properties = null, Envelope bbox = null, object id = null)
        {
            return new Feature() { Geometry = GeometryFactory.CreateLineString(coordinates), Attributes = properties, BoundingBox = bbox };
        }

        public static Feature MultiLineString(Coordinate[][] coordinates, AttributesTable properties = null, Envelope bbox = null, object id = null)
        {
            return new Feature()
            {
                Geometry = GeometryFactory.CreateMultiLineString(coordinates.Select(c => GeometryFactory.CreateLineString(c)).ToArray()),
                Attributes = properties,
                BoundingBox = bbox
            };
        }

        public static Feature MultiPoint(Coordinate[] coordinates, AttributesTable properties = null, Envelope bbox = null, object id = null)
        {
            return new Feature()
            {
                Geometry = GeometryFactory.CreateMultiPoint(coordinates.Select(x => GeometryFactory.CreatePoint(x)).ToArray()),
                Attributes = properties,
                BoundingBox = bbox
            };
        }
        public static Feature MultiPolygon(Coordinate[][] coordinates, AttributesTable properties = null, Envelope bbox = null, object id = null)
        {
            return new Feature()
            {
                Geometry = GeometryFactory.CreateMultiPolygon(coordinates.Select(x => GeometryFactory.CreatePolygon(x)).ToArray()),
                Attributes = properties,
                BoundingBox = bbox
            };
        }
        public static Feature Point(Coordinate coordinates, AttributesTable properties = null, Envelope bbox = null, object id = null)
        {
            return new Feature() { Geometry = GeometryFactory.CreatePoint(coordinates), Attributes = properties, BoundingBox = bbox };
        }
        public static Feature Polygon(Coordinate[] coordinates, AttributesTable properties = null, Envelope bbox = null, object id = null)
        {
            return new Feature() { Geometry = GeometryFactory.CreatePolygon(coordinates), Attributes = properties, BoundingBox = bbox };
        }


    }

}
