using Liinkz.Chat.Server.Models;

namespace Liinkz.Chat.Server
{
    public class UserRequestDTO
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }

    public class UserResponseDTO 
    {
        public UserResponseDTO(User user)
        {
            //UserId = user.UserId;
        }
        public string UserId { get; set; }
    }
}
