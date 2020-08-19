using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sipaz.Core.Interfaces;

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

        public IActionResult BasicDetails()
        {
            object masterData=_property.GetMasterData();
            return View();
        }


        public IActionResult PropertyFeautres()
        {
            return View();
        }

        public IActionResult PriceDetails()
        {
            return View();
        }

    }
}
