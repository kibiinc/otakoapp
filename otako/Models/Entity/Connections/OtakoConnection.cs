using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace otako.Models.Entity
{
    public class OtakoConnection
    {
        public ConnectionType Type { get; set; }
        public string Name { get; set; }
        public ulong Id { get; set; }
        public string ConnectionInfoJson { get; set; }
        public OtakoUser User { get; set; }
    }
}