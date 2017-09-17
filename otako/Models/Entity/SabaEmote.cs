using System;

namespace otako.Models.Entity
{
    public class SabaEmote
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string ContentId { get; set; }
        public string CreatorId { get; set; }
        public bool Managed { get; set; }
        public bool Global { get; set; }
        public bool RequireColons { get; set; }
        public EmoteType Type { get; set; }
        public OtakoSaba Saba { get; set; }
    }

    public enum EmoteType
    {
        Image = 0,
        Gif = 1
    }
}