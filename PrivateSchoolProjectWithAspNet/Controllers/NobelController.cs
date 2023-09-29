using NobelClientUsingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PrivateSchoolProjectWithAspNet.Controllers
{
    public class NobelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> GetLaureates()
        {
            try
            {
                var response = await NobelClient.GetAllFemaleLaureatesBornInGerDiedInUsa();

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { error.Message });
            }

        }
    }
}