using Microsoft.VisualStudio.TestTools.UnitTesting;
using Turf.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Turf.Net.Test
{
    [TestClass()]
    public class RandomTest
    {
        [TestMethod()]
        public void RandomPosition()
        {
            Turf.RandomPosition();
        }

        [TestMethod()]
        public void RandomPoint()
        {
            Turf.RandomPoint(10);
        }

     

        [TestMethod()]
        public void RandomLineString()
        {
            Turf.RandomLineString(10);
        }

   
        [TestMethod()]
        public void RandomPolygon()
        {
            Turf.RandomPolygon(10);
        }
         
    }
}