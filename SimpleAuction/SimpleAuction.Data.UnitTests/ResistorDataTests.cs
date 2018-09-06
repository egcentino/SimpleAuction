using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleAuction.Data.Providers;
using System.Collections.Generic;
using SimpleAuction.Core.Domain;

namespace SimpleAuction.Data.UnitTests
{
    [TestClass]
    public class ResistorDataTests
    {
        private InitDb _data = new InitDb();
        [TestMethod]
        [Ignore]
        public void CreateTables()
        {
            #region SQLs
            var sqlCreateColors = @"
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ResistorColor](
	[Name] [varchar](15) NOT NULL,
	[Code] [varchar](3) NULL,
	[SignificantFigures] [int] NULL,
	[Multiplier] [float] NULL,
	[Tolerance] [decimal](6, 3) NULL,
 CONSTRAINT [PK_ResistorColor] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

";
            var sqlCreateRequests = @"

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

--DROP TABLE [dbo].[ResistorCalculationRequest]

CREATE TABLE [dbo].[ResistorCalculationRequest](
	[Id] int IDENTITY(1,1) NOT NULL,
	[ColorBandA] [varchar](15) NOT NULL,
	[ColorBandB] [varchar](15) NOT NULL,
	[ColorBandC] [varchar](15) NOT NULL,
	[ColorBandD] [varchar](15) NOT NULL,
	[CalculatedValue] [float] NOT NULL ,
	[RequestDateUtc] [datetime2] NOT NULL 
 CONSTRAINT [PK_ResistorCalculationRequest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

";

            #endregion
            var db = _data;
            db.CreateTable(sqlCreateColors);
            db.CreateTable(sqlCreateRequests);
            db.LoadColors();
        }
        [TestMethod]
        [Ignore]
        public void InitTables()
        {
            _data.LoadColors();
        }

        private class InitDb : SqlServerData
        {
            public void CreateTable(string sql)
            {
                Save(sql, new KeyValuePair<string,object>[] { });
            }
            public void LoadColors()
            {
                var colors = new[]
            {
                new ResistorColor{ Name="None", Code=null, SignificantFigures=null, Multiplier=null, Tolerance=20 },
                new ResistorColor{ Name="Pink", Code="PK", SignificantFigures=null, Multiplier=.001, Tolerance=null },
                new ResistorColor{ Name="Silver", Code="SR", SignificantFigures=null, Multiplier=.01, Tolerance=10 },
                new ResistorColor{ Name="Gold", Code="GD", SignificantFigures=null, Multiplier=.1, Tolerance=5 },
                new ResistorColor{ Name="Black", Code="BK", SignificantFigures=0,   Multiplier=1, Tolerance=null },
                new ResistorColor{ Name="Brown", Code="BN", SignificantFigures=1,   Multiplier=10, Tolerance=1 },
                new ResistorColor{ Name="Red", Code="RD", SignificantFigures=2,     Multiplier=100, Tolerance=2 },
                new ResistorColor{ Name="Orange", Code="OG", SignificantFigures=3,  Multiplier=1000, Tolerance=.05m },
                new ResistorColor{ Name="Yellow", Code="YE", SignificantFigures=4,  Multiplier=10000, Tolerance=.02m },
                new ResistorColor{ Name="Green", Code="GN", SignificantFigures=5,   Multiplier=100000, Tolerance=.5m },
                new ResistorColor{ Name="Blue", Code="BU", SignificantFigures=6,    Multiplier=1000000, Tolerance=.25m },
                new ResistorColor{ Name="Violet", Code="VT", SignificantFigures=7,  Multiplier=10000000, Tolerance=.1m },
                new ResistorColor{ Name="Grey", Code="GY", SignificantFigures=8,    Multiplier=100000000, Tolerance=.01m },
                new ResistorColor{ Name="White", Code="WH", SignificantFigures=9,   Multiplier=1000000000, Tolerance=null },
            };
               
                foreach (var dataObject in colors)
                {
                    Save(dataObject, "ResistorColor");
                }
            }
        }
    }
}
