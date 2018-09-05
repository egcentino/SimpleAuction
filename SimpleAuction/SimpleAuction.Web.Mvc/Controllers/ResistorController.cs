using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleAuction.Web.Mvc.Models.Resistor;

using SimpleAuction.Service;

namespace SimpleAuction.Web.Mvc.Controllers
{
    public class ResistorController : Controller
    {
        private ResistorService _resistorService = new ResistorService();

        // GET: Resistor
        public ActionResult Index()
        {
            var model = new ResistorOhmCalculationViewModel
            {
            };
            DecorateModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ResistorOhmCalculationViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CalculatedResistance = _resistorService.GetResistance(model.BandAColor, model.BandBColor, model.BandCColor, model.BandDColor).ToString("#,##0.#####");
            }
            DecorateModel(model);
            return View(model);
        }

        private void DecorateModel(ResistorOhmCalculationViewModel model)
        {
            model.SignificantColors = GetSelectListItems(_resistorService.GetSignificantColors());
            model.MultiplierColors = GetSelectListItems(_resistorService.GetMultiplierColors());
            model.ToleranceColors = GetSelectListItems(_resistorService.GetToleranceColors());
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<Service.Resistors.ResistorMediator.Color> colors)
        {
            var lst = colors.Select(x => new SelectListItem { Value = x.Name, Text = x.Name }).ToList();
 
            return lst;
        }
    }
}