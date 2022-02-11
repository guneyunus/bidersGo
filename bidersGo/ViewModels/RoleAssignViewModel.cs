using System.Collections.Generic;

namespace bidersGo.ViewModels
{
    public class RoleAssignViewModel
    {
        public RoleUserAssignViewModel RoleUserAssignViewModel { get; set; }
        public List<RoleListViewModel> UserRoles { get; set; } = new();
    }
}
