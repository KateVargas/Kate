using System.Web.Mvc;
using WebProject.Repository;
using System.Collections.Generic;
using WebProject.Models;


namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var stateRepository = new StateRepository();
            ModelState.Clear();
            return View(stateRepository.GetAllStates());
        }

        public ActionResult GetAllCitiesByStateId(int stateId) {

            var cityRepository = new CityRepository();
            ModelState.Clear();
            var cities = cityRepository.GetAllCitiesByStateId(stateId);
            return Json(cities);
        }       
    }
}