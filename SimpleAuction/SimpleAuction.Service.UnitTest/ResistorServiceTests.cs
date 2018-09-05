using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SimpleAuction.Service.Resistors;
using System.Linq;

namespace SimpleAuction.Service.UnitTest
{
    [TestClass]
    public class ResistorServiceTests
    {
        [TestMethod]
        public void CalculateOhmTests()
        {
            // assume band colors are correct
            var calculator = new ResistorMediator();
            Assert.AreEqual(21000d, calculator.CalculateOhmValue("Red", "Brown", "Orange", ""));
            Assert.ThrowsException<OhmValueTruncationException>(() => { return calculator.CalculateOhmValue("Grey", "Grey", "White", ""); });
            // add all tests here
        }

        [TestMethod]
        public void FormatTests()
        {
            double val = 123124132;
            var txt = val.ToString("#,##0.#####");
        }
  
    }
}
