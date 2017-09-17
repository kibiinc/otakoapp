using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace otako.Models.Entity
{
    public class OtakoWarning
    {
        public int Id { get; set; }
        public OtakoUser User { get; set; }
        public string Issuer { get; set; }
        public string Details { get; set; }
        public WarningLevel Level { get; set; }
    }
}