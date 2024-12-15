using Microsoft.AspNetCore.SignalR;

namespace Liinkz.Chat.Server
{
    public class ChatHub : Hub
    {
        private static readonly Dictionary<string, string> _userConnections = new();

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            var connectionId = Context.ConnectionId;
            string userId = Context.UserIdentifier!;
            _userConnections[userId] = connectionId;
            Console.WriteLine($"{userId} is online with connectionId: {connectionId}");
        }

        public async Task SendDirectMessage(string userId, string message)
        {
            if (_userConnections.TryGetValue(userId, out var connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", userId, message);
            }
            else
            {
                Console.WriteLine($"User {userId} is offline.");
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            Console.WriteLine(exception);
            string userId = Context.UserIdentifier!;
            _userConnections.Remove(userId);
        }
    }

}
