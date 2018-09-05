using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SimpleAuction.Web.Mvc.Models.Resistor
{
    public class ResistorOhmCalculationViewModel
    {
        [Required]
        public string BandAColor { get; set; }
        [Required]
        public string BandBColor { get; set; }
        [Required]
        public string BandCColor { get; set; }
        [Required]
        public string BandDColor { get; set; }

        public string CalculatedResistance { get; set; }

        public IEnumerable<SelectListItem> SignificantColors { get; set; }
        public IEnumerable<SelectListItem> MultiplierColors { get; set; }
        public IEnumerable<SelectListItem> ToleranceColors { get; set; }
    }
}