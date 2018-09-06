using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SimpleAuction.Service.Resistors;
using System.Linq;
using System.Collections.Generic;
using SimpleAuction.Data;
using SimpleAuction.Core.Domain;

namespace SimpleAuction.Service.UnitTest
{
    [TestClass]
    public class ResistorServiceTests
    {
        private ResistorService _srvc = new ResistorService();
        private ResistorData _data = new ResistorData();
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

      

        [TestMethod]
        //[Ignore]
        public void SaveTest()
        {
            var srvc = _srvc;
            var data = _data;
            var req = GetRequest("Red", "Brown", "Green", "Silver");
            srvc.SaveRequest(req);
            req = GetRequest("Orange", "Blue", "Grey", "Gold");
            srvc.SaveRequest(req);
            srvc.SaveRequest(GetRequest("Green", "Green", "White", "Silver"));
     
        }
        [TestMethod]
        //[Ignore]
        public void GetTopRequestsTest()
        {
            var srvc = _srvc;
            var reqs = srvc.GetTopRequests(2).ToArray();
        }
        private ResistorCalculationRequest GetRequest(string bandA, string bandB, string bandC, string bandD)
        {
            var req = new ResistorCalculationRequest
            {
                ColorBandA = bandA,
                ColorBandB = bandB,
                ColorBandC = bandC,
                ColorBandD = bandD,
                RequestDateUtc = DateTime.UtcNow,
                CalculatedValue = _srvc.GetResistance(bandA, bandB, bandC, bandD)

            };
            return req;
        }
    }

}
