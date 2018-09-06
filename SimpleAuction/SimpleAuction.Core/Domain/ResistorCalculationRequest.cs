using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuction.Core.Domain
{
    public class ResistorCalculationRequest
    {
        public int Id { get; set; }
        public string ColorBandA { get; set; }
        public string ColorBandB { get; set; }
        public string ColorBandC { get; set; }
        public string ColorBandD { get; set; }
        public double CalculatedValue { get; set; }
        public DateTime RequestDateUtc { get; set; }
    }
}
