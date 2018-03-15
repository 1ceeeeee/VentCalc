using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VentCalc.Models;

namespace VentCalc.Controllers
{
    public class CityController : Controller
    {
        [HttpGet]
        public ActionResult CityList()
        {
            var model = new List<City>();
            model.Add(new City() {Id = 1, CityName = "Москва", TempOutWinter = 20, TempOutSummer =  30});
            model.Add(new City() {Id = 2, CityName = "Екатеринбург", TempOutWinter = 15.5 , TempOutSummer =  20.5} );
            model.Add(new City() {Id = 3, CityName = "Владивосток", TempOutWinter = 10.2, TempOutSummer =  12.2} );
            var modelJson = JsonConvert.SerializeObject(model); 
            return Json(modelJson);
        }
    }
}