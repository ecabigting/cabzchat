using Microsoft.AspNetCore.SignalR;

namespace cabzchat.Server.Hubs
{
    public class ChatHub : Hub
    {
        // dirty quick solution
    private static Dictionary<string, string> Users = new Dictionary<string, string>();
        public async Task SendMessageToChat(string msg, string username)
        {
            await Clients.All.SendAsync("GetThatMessage",username,msg);
        }

        public override async Task OnDisconnectedAsync(Exception? ex)
        {
            string username = Users.FirstOrDefault(u => u.Key == Context.ConnectionId).Value;
            await SendMessageToChat(string.Empty,$"{username} left the chat!"); 
        }

        public override async Task OnConnectedAsync()
        {
            string username = Context.GetHttpContext().Request.Query["username"];
            Users.Add(Context.ConnectionId,username);
            await SendMessageToChat(string.Empty,$"{username} entered the chat!");

            await base.OnConnectedAsync();
        }
    }
}