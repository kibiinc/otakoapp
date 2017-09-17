using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace otako.Models.Entity
{
    public class OtakoSense
    {
        public OtakoUser User { get; set; }
        public DateTime LastUpdated { get; set; }
        public SenseType Type { get; set; }
        public string HexColor { get; set; }
        public string Caption { get; set; }
    }

    public enum SenseType 
    {
        Online = 0,
        Idle = 1,
        DoNotDisturb = 2,
        Offline = 3,
        Stream = 4
    }
}