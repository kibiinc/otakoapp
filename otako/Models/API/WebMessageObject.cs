using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace otako.Models.API
{
    public class WebMessageObject
    {
        [JsonProperty("content")]
        public string content { get; set; }
        [JsonProperty("nonce")]
        public string nonce { get; set; }
    }
}