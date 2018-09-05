using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuction.Service
{
    public class ResistorService
    {
        public double GetResistance(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var mediator = new Resistors.ResistorMediator();
            return mediator.CalculateOhmValue2(bandAColor, bandBColor, bandCColor, bandDColor);
        }
     
        public IEnumerable<Resistors.ResistorMediator.Color> GetSignificantColors()
        {
            return Resistors.ResistorMediator.Color.Colors.Where(x => x.SignificantFigures != null);
        }
        public IEnumerable<Resistors.ResistorMediator.Color> GetMultiplierColors()
        {
            return Resistors.ResistorMediator.Color.Colors.Where(x => x.Multiplier != null);
        }
        public IEnumerable<Resistors.ResistorMediator.Color> GetToleranceColors()
        {
            return Resistors.ResistorMediator.Color.Colors.Where(x => x.Tolerance != null);
        }
    }
}
