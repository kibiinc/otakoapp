using System;
using Newtonsoft.Json;
using otako.WebSocket;

namespace otako.Models.WebSocket
{
    public class DispatchObject
    {
        [JsonProperty("e")]
        public DispatchType Type { get; set; }
        [JsonProperty("d")]
        public object Data { get; set; }
        [JsonProperty("op")]
        public int OpCode { get; set; }
        [JsonProperty("e_id")]
        public string EventId { get; set; }
    }

    public class DispatchListObject
    {
        public DispatchObject Data { get; set; }
        public DateTime LastSentAt { get; set; }
        public int Tries { get; set; }
    }

    public class TripObject
    {
        [JsonProperty("s")]
        public bool Success { get; set; }
        [JsonProperty("e_id")]
        public string EventId { get; set; }
    }
}