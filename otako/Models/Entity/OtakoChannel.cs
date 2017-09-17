using System;
using System.Collections.Generic;

namespace otako.Models.Entity
{
    public class OtakoChannel 
    {
        public OtakoChannel()
        {
            //finish this
        }
        
        public string Id { get; set; }
        public string Name { get; set; }
        public OtakoSaba Saba { get; set; }
        public virtual KeyValuePair<OtakoUser, ICollection<ChannelPermission>> UserPermissions { get; set; }
        public virtual KeyValuePair<SabaRole, ICollection<ChannelPermission>> RolePermissions { get; set; }
        public ChannelType Type { get; set; }
        //todo: finish modeling this, 9/10/17 (7:57pm)
    }
}