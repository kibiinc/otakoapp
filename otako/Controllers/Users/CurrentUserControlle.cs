using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace otako.Controllers.Views
{
    public class CurrentUserController : OtakoController
    {
        [Route("/u/@me")]
        [AcceptVerbs("GET")]
        public async Task<IActionResult> GetCurrentUser([FromQuery] string Auth)
        {
            return StatusCode(Json(new
            {
                codes = 1001,
                error = new
                {
                    message = "401 Unauthorized",
                    notes = "This endpoint has not yet been implemented."
                }
            }), 401);
        }

        [Route("/u/@me")]
        [AcceptVerbs("POST", "PATCH")]
        public async Task<IActionResult> UpdateCurrentUser([FromQuery] string Auth)
        {
            return StatusCode(Json(new
            {
                codes = 1001,
                error = new
                {
                    message = "401 Unauthorized",
                    notes = "This endpoint has not yet been implemented."
                }
            }), 401);
        }
    }
}
