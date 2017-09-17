using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using otako.WebSocket;
using UniqueIdGenerator;
using UniqueIdGenerator.Net;

namespace otako
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Global.Socket.Create();
            Global.Socket.Connect();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseIISIntegration()
                .UseUrls("http://localhost:8080")
                .Build();

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(timestamp);
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }

    public class Config
    {
        [JsonProperty("websocket_url")]
        public string WebSocketUrl { get; set; }
        [JsonProperty("websocket_token")]
        public string WebSocketToken { get; set; }
        [JsonProperty("db_connection_string")]
        public string DatabaseConnectionString { get; set; }
        [JsonProperty("machine_id")]
        public short MachineId { get; set; }
        [JsonProperty("flake_epoch_time")]
        public ulong SnowflakeStartTime { get; set; }

        public static Config GetConfig()
        {
            return JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
        }
    }

    public class Global
    {
        public static Config Config = Config.GetConfig();
        public static Generator Generator = new Generator(Config.MachineId, new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
        public static OtakoSocket Socket = new OtakoSocket();
    }

    public class OtakoFlake
    {
        public Generator Generator { get { return _Generator; } set { _Generator = value; } }
        private static Generator _Generator { get; set; }

        public OtakoFlake(bool autoCreate)
        {
            Generator = Global.Generator;
        }

        public OtakoFlake(Generator genToAdd)
        {
            Generator = genToAdd;
        }

        public OtakoFlake()
        {

        }

        public static string Next()
        {
            if (_Generator == null)
            {
                return Global.Generator.NextLong().ToString();
            }
            return _Generator.NextLong().ToString();
        }
    }
}
