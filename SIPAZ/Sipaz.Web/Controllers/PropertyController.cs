using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sipaz.Core.Interfaces;
using Sipaz.Core.Entities;

namespace Sipaz.Web.Controllers
{
    [Authorize]
    public class PropertyController : Controller
    {
        public IPropertyRent _property;
        public PropertyController(IPropertyRent property)
        {
            _property = property;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BasicDetails(int Id)
        {
            PropertyRentModel model =_property.GetMasterData();
            return View("_BasicDetails", model);
        }


        public IActionResult PropertyFeautres(int Id)
        {
            return View("_PropertyFeature");
        }

        public IActionResult PriceDetails(int Id)
        {
            return View("_PriceDetails");
        }



    }
}
