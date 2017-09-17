using System;
using Newtonsoft.Json;

namespace otako.Models.WebSocket
{
    public class MessageDispatch
    {
        [JsonProperty("c_id")]
        public string ChannelId { get; set; }
        [JsonProperty("m_id")]
        public string MessageId { get; set; }
        [JsonProperty("a_id")]
        public string AuthorId { get; set; }
    }
}