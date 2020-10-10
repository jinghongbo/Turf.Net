using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Turf.Net
{
    public static partial class Turf
    {
        public static Feature Along(Feature line, double distance, string units = "kilometers")
        {
            throw new NotImplementedException();
        }

        public static double Area(Feature feature)
        {
            throw new NotImplementedException();
        }
        public static double Area(FeatureCollection features)
        {
            throw new NotImplementedException();
        }

        public static Envelope Bbox(Feature feature)
        {
            throw new NotImplementedException();
        }
        public static Envelope Bbox(FeatureCollection features)
        {
            throw new NotImplementedException();
        }

        public static Feature BboxPolygon(Envelope bbox, AttributesTable properties = null, object id = null)
        {
            throw new NotImplementedException();

        }

        public static double Bearing(Coordinate start, Coordinate end, bool final = false)
        {
            throw new NotImplementedException();
        }

        public static Feature Center(Feature feature, AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }
        public static Feature Center(FeatureCollection features, AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }
        public static Feature CenterOfMass(Feature feature, AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }
        public static Feature CenterOfMass(FeatureCollection features, AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }
        public static Feature Centroid(Feature feature, AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }
        public static Feature Centroid(FeatureCollection features, AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }

        public static Feature Destination(Coordinate origin, double distance, double bearing, string units = "kilometers", AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }

        public static double Distance(Coordinate from, Coordinate to, string units = "kilometers")
        {
            throw new NotImplementedException();
        }

        public static Feature Envelope(FeatureCollection features)
        {
            throw new NotImplementedException();
        }

        public static double Length(FeatureCollection features, string units = "kilometers")
        {
            throw new NotImplementedException();
        }

        public static Feature Midpoint(Coordinate point1, Coordinate point2)
        {
            throw new NotImplementedException();
        }

        public static Feature PointOnFeature(FeatureCollection features)
        {

            throw new NotImplementedException();
        }

        public static FeatureCollection PolygonTangents(Coordinate pt, Feature polygon)
        {
            throw new NotImplementedException();
        }

        public static double PointToLineDistance(Coordinate pt, Feature line, string units = "kilometers", bool mercator = false)
        {
            throw new NotImplementedException();
        }

        public static double RhumbBearing(Coordinate start, Coordinate end, bool final = false)
        {
            throw new NotImplementedException();
        }

        public static Feature RhumbDestination(Coordinate origin, double distance, double bearing, string units = "kilometers", AttributesTable properties = null)
        {
            throw new NotImplementedException();
        }
        public static double RhumbDistance(Coordinate from, Coordinate to, string units = "kilometers")
        {
            throw new NotImplementedException();
        }

        public static Envelope Square(Envelope bbox)
        {
            throw new NotImplementedException();
        }
        public static Feature GreatCircle(Coordinate start, Coordinate end, AttributesTable properties = null, double npoints = 100, double offset = 10)
        {
            throw new NotImplementedException();
        }


    }
}
