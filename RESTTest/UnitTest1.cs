using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using oblikatoriskOpgave;
using RESTCykelService.Controllers;

namespace RESTTest
{
    [TestClass]
    public class UnitTest1
    {
        private CykelsController cntr = new CykelsController();

        [TestInitialize]
        public void BeforeEachMetod()
        {
            cntr = new CykelsController(); 
        }
        [TestMethod]
        public void Get()
        {
            Assert.AreEqual(4,new List<Cykel>(cntr.Get()).Count);
        }

        //[TestMethod]
        //public void GetById(int id)
        //{
        //    Assert.AreEqual(1,new List<Cykel>(cntr.Get()).Exists());
        //}

        //[TestMethod]
        //public void Post()
        //{

        //}
    }
}
