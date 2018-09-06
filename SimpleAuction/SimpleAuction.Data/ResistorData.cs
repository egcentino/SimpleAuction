using SimpleAuction.Core.Data;
using SimpleAuction.Core.Domain;
using SimpleAuction.Data.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuction.Data
{
    public class ResistorData : SqlServerData, IResistorData
    {
        private static ResistorColor[] _colors;
        public ResistorData() : base(null)
        {
        }
        public IEnumerable<ResistorColor> GetColors()
        {
            if (_colors == null)
            {
                _colors = Select<ResistorColor>("SELECT * FROM ResistorColor", new KeyValuePair<string, object>[] { }
                          , (rdr) => {
                              var t = new ResistorColor
                              {
                                  Name = rdr.GetString(0),
                                  Code = GetValue<string>(rdr.GetValue(1)),
                                  SignificantFigures = GetValue<int?>(rdr.GetValue(2)),
                                  Multiplier = GetValue<double?>(rdr.GetValue(3)),
                                  Tolerance = GetValue<decimal?>(rdr.GetValue(4))
                              };
                              return t;
                          }).ToArray();
            }
            return _colors;
        }

        public IEnumerable<ResistorCalculationRequest> GetTopRequests(int rowCount)
        {
            return Select<ResistorCalculationRequest>($"SELECT TOP {rowCount} * FROM ResistorCalculationRequest ORDER BY CalculatedValue desc", new KeyValuePair<string, object>[] { }
            , (rdr) =>
            {
                return new ResistorCalculationRequest
                {
                    Id = rdr.GetInt32(0),
                    ColorBandA = rdr.GetString(1),
                    ColorBandB = rdr.GetString(2),
                    ColorBandC = rdr.GetString(3),
                    ColorBandD = rdr.GetString(4),
                    CalculatedValue = rdr.GetDouble(5),
                    RequestDateUtc = rdr.GetDateTime(6)
                };
            });
        }

        public int SaveCalculateRequest(ResistorCalculationRequest request)
        {
            return Save(request);
        }
    }
}
