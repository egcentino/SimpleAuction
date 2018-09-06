using SimpleAuction.Core.Domain;
using SimpleAuction.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuction.Service
{
    public class ResistorService
    {
        private ResistorData _data = new ResistorData();
        public double GetResistance(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var mediator = new Resistors.ResistorMediator();
            return mediator.CalculateOhmValue2(bandAColor, bandBColor, bandCColor, bandDColor);
        }
     
        public IEnumerable<ResistorColor> GetSignificantColors()
        {
            return _data.GetColors().Where(x => x.SignificantFigures != null);
        }
        public IEnumerable<ResistorColor> GetMultiplierColors()
        {
            return _data.GetColors().Where(x => x.Multiplier != null);
        }
        public IEnumerable<ResistorColor> GetToleranceColors()
        {
            return _data.GetColors().Where(x => x.Tolerance != null);
        }

        public void SaveRequest(ResistorCalculationRequest request)
        {
            _data.SaveCalculateRequest(request);
        }
        public IEnumerable<ResistorCalculationRequest> GetTopRequests(int rowCount)
        {
            return _data.GetTopRequests(rowCount);
        }
    }
}
