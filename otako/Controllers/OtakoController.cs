using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using otako.Models.Entity;
using otako.WebSocket;

namespace otako.Controllers
{
    ///<summary>
    /// The official custom class for the Otako API Controllers.
    ///</summary>
    public class OtakoController : Controller
    {
        public OtakoContext Context = null;
        public OtakoSocket Socket = Global.Socket;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        ///<summary>
        /// Returns JSON data based on status code.
        ///</summary>
        public IActionResult StatusCode(JsonResult OriginalResult, int StatusCode = 200)
        {
            OriginalResult.StatusCode = StatusCode;
            return OriginalResult;
        }
    }
}