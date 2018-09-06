using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuction.Core.Domain
{
    public class ResistorColor
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int? SignificantFigures { get; set; }
        public double? Multiplier { get; set; }
        public decimal? Tolerance { get; set; }
    }
}
