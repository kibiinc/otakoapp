using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace otako.Models.Entity
{
    public class OtakoUser
    {
        public OtakoUser()
        {
            Connections = new HashSet<OtakoConnection>();
            LoggedIps = new HashSet<string>();
            Sabas = new HashSet<OtakoSaba>();
            Warnings = new HashSet<OtakoWarning>();
            SabaMembers = new HashSet<SabaMember>();
            Relationships = new HashSet<OtakoRelationship>();
            Features = new HashSet<OtakoFeature>();
            Flags = new HashSet<OtakoFlag>();
        }

        [Key]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Tagu { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string AvatarId { get; set; }
        public string Hash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CountryCode { get; set; }
        public string TwoFactorToken { get; set; }
    
        public bool Disabled { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<string> LoggedIps { get; set; }
        public VerificationLevel VerificationLevel { get; set; }
        public WarningLevel WarningLevel { get; set; }
        public OtakoSense Sense { get; set; }

        public virtual ICollection<OtakoConnection> Connections { get; set; }
        public virtual ICollection<OtakoWarning> Warnings { get; set; }
        public virtual ICollection<OtakoSaba> Sabas { get; set; }
        public virtual ICollection<OtakoPrivateChannel> Channels { get; set; }
        public virtual ICollection<SabaMember> SabaMembers { get; set; }
        public virtual ICollection<OtakoRelationship> Relationships { get; set; }
        public virtual ICollection<OtakoFeature> Features { get; set; }
        public virtual ICollection<OtakoFlag> Flags { get; set; }

    }
}