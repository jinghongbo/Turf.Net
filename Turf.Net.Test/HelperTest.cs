using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using System.Linq;

namespace Turf.Net.Test
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void FeatureCollection()
        {
            var locationA = Turf.RandomPoint();
            var locationB = Turf.RandomPoint();
            var locationC = Turf.RandomPoint();
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
            var geometry = Turf.RandomPoint().Geometry;
            var feature = Turf.Feature(geometry);

            Assert.IsNotNull(feature);
            Assert.AreEqual(feature.Geometry, geometry);
        }

        [TestMethod]
        public void GeometryCollection()
        {

            var pt = Turf.RandomPoint().Geometry;
            var line = Turf.RandomLineString().Geometry;
            var collection = Turf.GeometryCollection(new Geometry[] { pt, line });

            Assert.IsNotNull(collection);
            Assert.AreEqual(collection.Geometry.GetGeometryN(0), pt);
            Assert.AreEqual(collection.Geometry.GetGeometryN(1), line);
        }

        [TestMethod]
        public void LineString()
        {
            var lineString1 = Turf.LineString(Turf.RandomLineString().Geometry.Coordinates, new AttributesTable { { "name", "line 1" } }); ;


            var lineString2 = Turf.LineString(Turf.RandomLineString().Geometry.Coordinates, new AttributesTable { { "name", "line 2" } });

            Assert.IsNotNull(lineString1);
            Assert.IsNotNull(lineString2);

            Assert.AreEqual(lineString1.Geometry.OgcGeometryType, OgcGeometryType.LineString);
            Assert.AreEqual(lineString2.Geometry.OgcGeometryType, OgcGeometryType.LineString);
        }

        [TestMethod]
        public void MultiLineString()
        {
            var multiLineString = Turf.MultiLineString(Turf.RandomLineString(2).Select(x => x.Geometry.Coordinates).ToArray());

            Assert.IsNotNull(multiLineString);
            Assert.AreEqual(multiLineString.Geometry.OgcGeometryType, OgcGeometryType.MultiLineString);

        }

        [TestMethod]
        public void MultiPoint()
        {
            var multiPt = Turf.MultiPoint(Turf.RandomPoint(2).Select(x => x.Geometry.Coordinate).ToArray());
            Assert.IsNotNull(multiPt);
            Assert.AreEqual(multiPt.Geometry.OgcGeometryType, OgcGeometryType.MultiPoint);
        }
        [TestMethod]
        public void MultiPolygon()
        {
            var multiPoly = Turf.MultiPolygon(Turf.RandomPolygon(2).Select(x => x.Geometry.Coordinates).ToArray());
            Assert.IsNotNull(multiPoly);
            Assert.AreEqual(multiPoly.Geometry.OgcGeometryType, OgcGeometryType.MultiPolygon);
        }
        [TestMethod]

        public void Point()
        {
            var pt = Turf.Point(Turf.RandomPosition());
            Assert.IsNotNull(pt);
            Assert.AreEqual(pt.Geometry.OgcGeometryType, OgcGeometryType.Point);
        }
        [TestMethod]
        public void Polygon()
        {
            var poly = Turf.Polygon(Turf.RandomPolygon().Geometry.Coordinates);
            Assert.IsNotNull(poly);
            Assert.AreEqual(poly.Geometry.OgcGeometryType, OgcGeometryType.Polygon);
        }
    }
}
