using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuction.Service.Resistors
{
    public class OhmValueTruncationException : ApplicationException
    {
        public OhmValueTruncationException(int value, double value2):this("Result has been truncated", value, value2) { }
        public OhmValueTruncationException(string message, int value, double value2) : base(message)
        {
            Value = value;
            Value2 = value2;
        }

        public int Value { get; set; }
        public double Value2 { get; set; }
    }
}
