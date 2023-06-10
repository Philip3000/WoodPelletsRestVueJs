using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoodPelletsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib.Tests
{
    [TestClass()]
    public class WoodPelletTests
    {
        WoodPellet woodPellet = new WoodPellet();
       
        [TestMethod()]
        public void ValidateBrandTest()
        {
            woodPellet.Brand = "h";
            Assert.ThrowsException<ArgumentException>(() => woodPellet.ValidateBrand(woodPellet.Brand));
        }


        [TestMethod()]
        public void ValidateQualityTest()
        {
            woodPellet.Quality = 6;
            Assert.ThrowsException<ArgumentException>(() => woodPellet.ValidateQuality(woodPellet.Quality));
            woodPellet.Quality = 0;
            Assert.ThrowsException<ArgumentException>(() => woodPellet.ValidateQuality(woodPellet.Quality));
        }
    }
}