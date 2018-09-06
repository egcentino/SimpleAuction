using SimpleAuction.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuction.Core.Data
{
    public interface IResistorData
    {
        IEnumerable<ResistorColor> GetColors();
        int SaveCalculateRequest(ResistorCalculationRequest request);
        IEnumerable<ResistorCalculationRequest> GetTopRequests(int rowCount);
    }
}
