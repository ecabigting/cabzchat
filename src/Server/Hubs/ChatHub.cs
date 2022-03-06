using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string msg, string username)
        {
            await Clients.All.SendAsync("GetThatMessage",username,msg);
        }
    }
}