using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace otako.Models.Entity
{
    public class OtakoRelationship
    {
        public OtakoUser User { get; set; }
        public RelationshipType Type { get; set; }
    }
}

