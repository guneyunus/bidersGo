using System.Collections.Generic;

namespace bidersGo.ViewModels
{
    public class RoleUserAssignViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> UserRoles { get; set; } = new();
    }
}
