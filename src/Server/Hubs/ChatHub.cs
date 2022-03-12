using Microsoft.AspNetCore.SignalR;

namespace cabzchat.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageToChat(string msg, string username)
        {
            await Clients.All.SendAsync("GetThatMessage",username,msg);
        }

        public override async Task OnConnectedAsync()
        {
            await SendMessageToChat("","User Connected!");

            await base.OnConnectedAsync();
        }
    }
}