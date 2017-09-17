using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using otako.Models.WebSocket;
using SuperSocket.ClientEngine;
using WebSocket4Net;
using ws = WebSocket4Net;

namespace otako.WebSocket
{
    public class OtakoSocket
    {
        //TODO: Write a thread that constantly checks if the WebSocket connection is active, and recconnect if it is not!
        //above may have been magically fixed for some reason idk why ??
        

        private ws.WebSocket _socket { get; set; }
        private bool SocketCreated = false;
        private bool SocketActive = false;
        private HashSet<DispatchListObject> Dispatches = new HashSet<DispatchListObject>();
        Thread LoopThread { get; set; }
        private bool SocketConnecting = false;
        private bool SocketConnectedBefore = false;

        public void Connect()
        {
            if (!SocketCreated)
            {
                throw new Exception("Socket has not been initiliazed!");
            }

            if (!LoopThread.IsAlive)
            {
                LoopThread.Start();
            }

            if (SocketConnectedBefore)
            {
                Logger.Log("[SOCKET]", "Attemptting to reconnect to the Gateway!");
            }

            SocketConnecting = true;
            _socket.Open();

            //Logger.Log("[SOCKET]", "Connection created!");
        }

        public bool Create()
        {
            List<KeyValuePair<string, string>> HeaderItems = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Auth", Global.Config.WebSocketToken)
            };

            _socket =
            new ws.WebSocket(Global.Config.WebSocketUrl,
            subProtocol: null,
            version: ws.WebSocketVersion.None,
            cookies: null,
            customHeaderItems: HeaderItems);

            _socket.Opened += new EventHandler(OnOpen);
            _socket.Error += new EventHandler<ErrorEventArgs>(OnError);
            _socket.Closed += new EventHandler(OnClose);
            _socket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(OnMessage);

            LoopThread = new Thread(LoopAndParse);

            SocketCreated = true;

            Logger.Log("[SOCKET]", "Services ready!");

            return SocketCreated;
        }

        public void Dispatch(object Payload, DispatchType Type)
        {
            switch (Type)
            {
                case DispatchType.UserUpdate:
                    {
                        break;
                    }
                case DispatchType.UserSenseUpdate:
                    {
                        break;
                    }
                case DispatchType.AccountDelete:
                    {
                        break;
                    }
                case DispatchType.AccountDisable:
                    {
                        break;
                    }
                case DispatchType.UpdateAvaliable:
                    {
                        break;
                    }
                case DispatchType.ServiceDown:
                    {
                        break;
                    }
                case DispatchType.MessageCreate:
                    {
                        var p = Payload as MessageDispatch;
                        DispatchObject Data = new DispatchObject()
                        {
                            OpCode = 0,
                            Data = p,
                            Type = DispatchType.MessageCreate,
                            EventId = OtakoFlake.Next()
                        };
                        Send(Data);
                        break;
                    }
                case DispatchType.MessageUpdate:
                    {
                        break;
                    }
                case DispatchType.MessageDelete:
                    {
                        break;
                    }
                case DispatchType.MessageBulkDelete:
                    {
                        break;
                    }
                case DispatchType.MessageHannoAdd:
                    {
                        break;
                    }
                case DispatchType.MessageHannoRemove:
                    {
                        break;
                    }
                case DispatchType.MessageHannoRemoveAll:
                    {
                        break;
                    }
                case DispatchType.SabaCreate:
                    {
                        break;
                    }
                case DispatchType.SabaUpdate:
                    {
                        break;
                    }
                case DispatchType.SabaDelete:
                    {
                        break;
                    }
                case DispatchType.ChannelCreate:
                    {
                        break;
                    }
                case DispatchType.ChannelUpdate:
                    {
                        break;
                    }
                case DispatchType.ChannelDelete:
                    {
                        break;
                    }
                case DispatchType.RoleCreate:
                    {
                        break;
                    }
                case DispatchType.RoleUpdate:
                    {
                        break;
                    }
                case DispatchType.RoleDelete:
                    {
                        break;
                    }
                case DispatchType.WebhookUpdate:
                    {
                        break;
                    }
                case DispatchType.ServiceUpdate:
                    {
                        break;
                    }
                case DispatchType.Execution:
                    {
                        break;
                    }
                case DispatchType.RelationshipAdd:
                    {
                        break;
                    }
                case DispatchType.RelationshipRemove:
                    {
                        break;
                    }
            }
        }


        private void Send(DispatchObject Data)
        {
            if (!SocketActive) return;
            _socket.Send(JsonConvert.SerializeObject(Data));
            Dispatches.Add(new DispatchListObject
            {
                Data = Data,
                LastSentAt = DateTime.Now,
                Tries = 1
            });

            return;
        }

        private void Send(DispatchListObject NewData)
        {
            if (!SocketActive) return;
            _socket.Send(JsonConvert.SerializeObject(NewData.Data));

            var Event = Dispatches.FirstOrDefault(x => x.Data.EventId == NewData.Data.EventId);
            if (Event == null) return;
            Event.Tries++;
            Event.LastSentAt = DateTime.Now;

            return;
        }

        private void OnMessage(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                var Trip = JsonConvert.DeserializeObject<TripObject>(e.Message);
                if (Trip.Success)
                {
                    Dispatches.RemoveWhere(x => x.Data.EventId == Trip.EventId);
                }
                else
                {
                    var Event = Dispatches.FirstOrDefault(x => x.Data.EventId == Trip.EventId);
                    if (Event == null) return;
                    Send(Event);
                }
            }
            catch (Exception x)
            {
                Logger.Log("[SOCKET]", "Gateway sent invalid JSON!");
            }
        }

        private void OnError(object sender, ErrorEventArgs e)
        {
            Logger.Log("[SOCKET]", "Gateway error! " + e.Exception.Message);
            _socket.Close();

            // Logger.Log("[SOCKET]", "Restarting WebSocket connection!");
        }

        private void OnOpen(object sender, EventArgs e)
        {
            Logger.Log("[SOCKET]", "Connected to Gateway!");
            SocketConnecting = false;
            SocketActive = true;
            SocketConnectedBefore = true;
        }

        private void OnClose(object sender, EventArgs e)
        {
            Logger.Log("[SOCKET]", "Gateway connection closed!");
            SocketActive = false;
            if (!SocketConnectedBefore) SocketConnecting = false;

            //Logger.Log("[SOCKET]", "Attempt reconnect to Gateway!");
        }

        private void LoopAndParse()
        {
            while (true)
            {
                if (!SocketActive && !SocketConnecting)
                {
                    SocketConnecting = true;
                    Connect();
                }

                foreach (DispatchListObject Item in Dispatches.ToList())
                {
                    if (Item.Tries > 32)
                    {
                        Dispatches.Remove(Item);
                        Logger.Log("[SOCKET]", $"Event {Item.Data.EventId} was dropped!");
                    }
                    else
                    {
                        TimeSpan s = DateTime.Now - Item.LastSentAt;

                        if (s.TotalSeconds > 10)
                        {
                            Send(Item);
                        }
                    }
                }

                Thread.Sleep(5000);
            }
        }

    }
}