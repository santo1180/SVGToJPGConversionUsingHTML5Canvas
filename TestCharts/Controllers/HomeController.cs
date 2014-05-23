using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestCharts.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveImage(string imageData)
        {

            string fileNameWitPath = ConfigurationManager.AppSettings["ImageLocation"] + DateTime.Now.ToString().Replace("/", "-").
                Replace(" ", "- ").Replace(":", "") + ".png";

            using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }

            return new JsonResult() { Data = true };
        }
    }
}