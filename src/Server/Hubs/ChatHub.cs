using Microsoft.AspNetCore.SignalR;

namespace cabzchat.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string msg, string username)
        {
            await Clients.All.SendAsync("GetThatMessage",username,msg);
        }

        public override async Task OnConnectedAsync()
        {
            await SendMessage("","User Connected!");

            await base.OnConnectedAsync();
        }
    }
}