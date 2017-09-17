using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace otako.Models.Entity
{
    public class OtakoPrivateChannel
    {
        public OtakoPrivateChannel()
        {

        }
        
        public PrivateChannelType Type { get; set; }
        public ICollection<OtakoUser> Users { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        //todo: model this class
    }

    public enum PrivateChannelType
    {
        Dm = 0,
        Group = 1
    }
}