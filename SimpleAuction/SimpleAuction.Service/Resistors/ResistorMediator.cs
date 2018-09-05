using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuction.Service.Resistors
{
    public class ResistorMediator : IOhmValueCalculator2
    {
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var value = CalculateOhmValue2(bandAColor, bandBColor, bandCColor, bandDColor);
            var intValue = (int)value;
            if (intValue != value)
            {
                throw new OhmValueTruncationException($"Result has exceeded data type max value. Result={value}, MaxCapacity={int.MaxValue}", intValue, value);
            }
            return intValue;
        }

        public double CalculateOhmValue2(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            if (!IsValidSignificantBandColor(bandAColor)) throw new ResistorBandColorException($"BandA color is not valid. color={bandAColor}");
            if (!IsValidSignificantBandColor(bandBColor)) throw new ResistorBandColorException($"BandB color is not valid. color={bandBColor}");
            // More validation will be implemented later
            var significantNumber = Color.Colors.Single(x => x.Name == bandAColor).SignificantFigures.Value * 10
                + Color.Colors.Single(x => x.Name == bandBColor).SignificantFigures.Value;
            var result = significantNumber * Color.Colors.Single(x => x.Name == bandCColor).Multiplier.Value;
            return result;
        }

        private static bool IsValidSignificantBandColor(string bandColor)
        {
            return Color.Colors.FirstOrDefault(x => x.Name == bandColor)?.SignificantFigures != null;
        }

        public class Color
        {
            public static readonly Color[] Colors = new[]
            {
                new Color{ Name="None", Code=null, SignificantFigures=null, Multiplier=null, Tolerance=20 },
                new Color{ Name="Pink", Code="PK", SignificantFigures=null, Multiplier=.001, Tolerance=null },
                new Color{ Name="Silver", Code="SR", SignificantFigures=null, Multiplier=.01, Tolerance=10 },
                new Color{ Name="Gold", Code="GD", SignificantFigures=null, Multiplier=.1, Tolerance=5 },
                new Color{ Name="Black", Code="BK", SignificantFigures=0,   Multiplier=1, Tolerance=null },
                new Color{ Name="Brown", Code="BN", SignificantFigures=1,   Multiplier=10, Tolerance=1 },
                new Color{ Name="Red", Code="RD", SignificantFigures=2,     Multiplier=100, Tolerance=2 },
                new Color{ Name="Orange", Code="OG", SignificantFigures=3,  Multiplier=1000, Tolerance=.05m },
                new Color{ Name="Yellow", Code="YE", SignificantFigures=4,  Multiplier=10000, Tolerance=.02m },
                new Color{ Name="Green", Code="GN", SignificantFigures=5,   Multiplier=100000, Tolerance=.5m },
                new Color{ Name="Blue", Code="BU", SignificantFigures=6,    Multiplier=1000000, Tolerance=.25m },
                new Color{ Name="Violet", Code="VT", SignificantFigures=7,  Multiplier=10000000, Tolerance=.1m },
                new Color{ Name="Grey", Code="GY", SignificantFigures=8,    Multiplier=100000000, Tolerance=.01m },
                new Color{ Name="White", Code="WH", SignificantFigures=9,   Multiplier=1000000000, Tolerance=null },
            };
            public string Name { get; set; }
            public string Code { get; set; }
            public int? SignificantFigures { get; set; }
            public double? Multiplier { get; set; }
            public decimal? Tolerance { get; set; }
        }
    }
}
