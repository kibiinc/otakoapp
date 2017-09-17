using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace otako.Models.Entity
{
    public class SabaMember
    {
        public SabaMember()
        {
            Roles = new HashSet<SabaRole>();
        }

        [Key]
        public int JoinId { get; set; }
        public OtakoSaba Saba { get; set; }
        public OtakoUser User { get; set; }
        public virtual ICollection<SabaRole> Roles { get; set; }
        public DateTime JoinedAt { get; set; }
        public bool Deaf { get; set; } //Not implemented until voice is.
        public bool Muted { get; set; } //not implemented until voice is.
    }
}