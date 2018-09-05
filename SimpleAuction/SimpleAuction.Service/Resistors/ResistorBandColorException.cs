using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuction.Service.Resistors
{
    public class ResistorBandColorException : Exception
    {
        public ResistorBandColorException(string message) : base(message) { }
    }
}
