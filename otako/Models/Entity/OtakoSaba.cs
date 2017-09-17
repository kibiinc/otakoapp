using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace otako.Models.Entity
{
    public class OtakoSaba
    {
        public OtakoSaba()
        {
            Features = new HashSet<SabaFeature>();
            Members = new HashSet<SabaMember>();
            Channels = new HashSet<OtakoChannel>();
            Roles = new HashSet<SabaRole>();
            Emotes = new HashSet<SabaEmote>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public OtakoUser Owner { get; set; }
        public string Region { get; set; }
        public virtual ICollection<SabaFeature> Features { get; set; }
        public virtual ICollection<SabaMember> Members { get; set; }
        public virtual ICollection<OtakoChannel> Channels { get; set; }
        public virtual ICollection<SabaRole> Roles { get; set; }
        public virtual ICollection<SabaEmote> Emotes { get; set; }
        //todo create sabaemote class
        public VerificationLevel Level { get; set; }
        public bool DefaultNotifications { get; set; }
        public bool ContentFilter { get; set; } //not yet implemented
        public string Splash { get; set; }
        public string Icon { get; set; }
        public int AfkTimeout { get; set; }// not yet implemented

        //todo add checks for duplicates and finish modeling

    }
}