using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using otako.Models.API;
using otako.Models.WebSocket;
using otako.WebSocket;

namespace otako.Controllers.Views
{
    public class ChannelController : OtakoController
    {
        [Route("/c/{id}")]
        [AcceptVerbs("GET")]
        public async Task<IActionResult> GetChannel([FromRoute] string id)
        {
            return Ok();
        }

        [Route("/c/{id}/m")]
        [AcceptVerbs("POST")]
        public async Task<IActionResult> CreateMessage([FromRoute] string id, [FromBody] WebMessageObject Message)
        {
            return Json(new
            {
                content = Message.content,
                nonce = Message.nonce
            });
        }
    }
}