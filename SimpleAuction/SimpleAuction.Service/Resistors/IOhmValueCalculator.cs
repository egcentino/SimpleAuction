﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuction.Service.Resistors
{
    public interface IOhmValueCalculator
    {
        /// <summary> 
        /// Calculates the Ohm value of a resistor based on the band colors. /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal multiplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param> 
        int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }

    /// <summary>
    /// Extension of IOhmValueCalculator to provide a method that returns a double data type
    /// </summary>
    public interface IOhmValueCalculator2 : IOhmValueCalculator
    {
        double CalculateOhmValue2(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }
}
