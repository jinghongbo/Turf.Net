using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using System.Linq;
using System.Reflection.PortableExecutable;
using static Turf.Net.Test.RandomHelper;

namespace Turf.Net.Test
{
    [TestClass]
    public class Helper
    {
        [TestMethod]
        public void FeatureCollection()
        {
            var locationA = Turf.Point(RandomCoordinate(), new AttributesTable { { "name", "Location A" } });
            var locationB = Turf.Point(RandomCoordinate(), new AttributesTable { { "name", "Location B" } });
            var locationC = Turf.Point(RandomCoordinate(), new AttributesTable { { "name", "Location C" } });
            var collection = Turf.FeatureCollection(new[] {
              locationA,
              locationB,
              locationC
            });

            Assert.IsNotNull(collection);
            Assert.AreEqual(collection[0], locationA);
            Assert.AreEqual(collection[1], locationB);
            Assert.AreEqual(collection[2], locationC);

        }

        [TestMethod]
        public void Feature()
        {
            var geometry = Turf.GeometryFactory.CreatePoint(RandomCoordinate());
            var feature = Turf.Feature(geometry);

            Assert.IsNotNull(feature);
            Assert.AreEqual(feature.Geometry, geometry);
        }

        [TestMethod]
        public void GeometryCollection()
        {
            var pt = Turf.GeometryFactory.CreatePoint(RandomCoordinate());
            var line = Turf.GeometryFactory.CreateLineString(RandomCoordinates());
            var collection = Turf.GeometryCollection(new Geometry[] { pt, line });

            Assert.IsNotNull(collection);
            Assert.AreEqual(collection.Geometry.GetGeometryN(0), pt);
            Assert.AreEqual(collection.Geometry.GetGeometryN(1), line);
        }

        [TestMethod]
        public void LineString()
        {
            var lineString1 = Turf.LineString(RandomCoordinates(), new AttributesTable { { "name", "line 1" } });


            var lineString2 = Turf.LineString(RandomCoordinates(), new AttributesTable { { "name", "line 2" } });

            Assert.IsNotNull(lineString1);
            Assert.IsNotNull(lineString2);

            Assert.AreEqual(lineString1.Geometry.OgcGeometryType, OgcGeometryType.LineString);
            Assert.AreEqual(lineString2.Geometry.OgcGeometryType, OgcGeometryType.LineString);
        }

        [TestMethod]
        public void MultiLineString()
        {
            var multiLineString = Turf.MultiLineString(new Coordinate[][] { RandomCoordinates(), RandomCoordinates() });

            Assert.IsNotNull(multiLineString);
            Assert.AreEqual(multiLineString.Geometry.OgcGeometryType, OgcGeometryType.MultiLineString);

        }

        [TestMethod]
        public void MultiPoint()
        {
            var multiPt = Turf.MultiPoint(RandomCoordinates());
            Assert.IsNotNull(multiPt);
            Assert.AreEqual(multiPt.Geometry.OgcGeometryType, OgcGeometryType.MultiPoint);
        }
        [TestMethod]
        public void MultiPolygon()
        {
            var multiPoly = Turf.MultiPolygon(new Coordinate[][] { RandomCoordinates(true), RandomCoordinates(true) });
            Assert.IsNotNull(multiPoly);
            Assert.AreEqual(multiPoly.Geometry.OgcGeometryType, OgcGeometryType.MultiPolygon);
        }
        [TestMethod]

        public void Point()
        {
            var pt = Turf.Point(RandomCoordinate());
            Assert.IsNotNull(pt);
            Assert.AreEqual(pt.Geometry.OgcGeometryType, OgcGeometryType.Point);
        }
        [TestMethod]
        public void Polygon()
        {
            var poly = Turf.Polygon(RandomCoordinates(true));
            Assert.IsNotNull(poly);
            Assert.AreEqual(poly.Geometry.OgcGeometryType, OgcGeometryType.Polygon);
        }
    }
}
