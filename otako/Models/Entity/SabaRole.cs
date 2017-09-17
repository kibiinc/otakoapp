using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace otako.Models.Entity
{
    public class SabaRole
    {
        public SabaRole()
        {
            Permissions = new HashSet<RolePermission>();
            Members = new HashSet<SabaMember>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RolePermission> Permissions { get; set; }
        public virtual ICollection<SabaMember> Members { get; set; }
        public OtakoSaba Saba { get; set; }
        public string HexColor { get; set; }
        public bool Hoisted { get; set; }
        public bool Managed { get; set; }
        public int Position { get; set; } 
        /*
            Note, Hierchy is to be implemented after basic role system is working, 
            for now, all hierchies are to auto increment until custom moving 
            is implemented.

            TODO: add some EF Core checks for the Many-To-Many relationship going on
        */
    }
}