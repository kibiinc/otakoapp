using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace otako.Controllers.Views
{
    public class ViewController : OtakoController
    {
        [Route("/")]
        [AcceptVerbs("GET")]
        public IActionResult GetHomePage()
        {
           var data = System.IO.File.ReadAllBytes("wwwroot/index.html");
           return File(data, "text/html");
        }

        [Route("/")]
        [AcceptVerbs("POST", "PATCH", "PUT", "DELETE", "COPY", "HEAD", "LINK", "UNLINK", "PURGE", "LOCK", "UNLOCK", "PROPFIND", "VIEW", "OPTIONS")]
        public IActionResult ReturnInformation()
        {
            return StatusCode(Json(new
            {
                codes = 0,
                error = new
                {
                    message = "405 Method Not Allowed",
                    notes = "Refer to https://api.otakoapp.com/ for more info."
                }
            }), 405);
        }
    }
}