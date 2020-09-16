using Microsoft.VisualStudio.TestTools.UnitTesting;
using oblikatoriskOpgave;
using System;
using System.Collections.Generic;
using System.Text;

namespace oblikatoriskOpgave.Tests
{
    
    [TestClass()]
    public class CykelTests
    {
        private Cykel c1;

        [TestInitialize]
        public void Init()
        {
            c1 = new Cykel(1,"blue",1000,3);
        }

        [TestMethod()]
        public void IdTest()
        {
            Assert.AreEqual(1, c1.Id);
            c1.Id = 2;
        }

        [TestMethod()]
        public void ColorTest()
        {
            Assert.AreEqual("blue", c1.Color);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => c1.Color = "");
            c1.Color = "Red";
        }

        [TestMethod()]
        public void PriceTest()
        {
            Assert.AreEqual(1000,c1.Price);
            Assert.ThrowsException<ArgumentNullException>(() => c1.Price = -1);
            c1.Price = 100;

        }

        [TestMethod()]
        public void GearTest()
        {
            Assert.AreEqual(3, c1.Gear);
            c1.Gear = 16;
            Assert.AreEqual(16,c1.Gear);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => c1.Gear = 2);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => c1.Gear = 33);

        }
    }
}