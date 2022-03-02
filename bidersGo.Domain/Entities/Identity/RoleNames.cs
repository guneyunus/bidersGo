using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Domain.Entities.Identity
{
    public static class RoleNames
    {
        public static string Admin = "Admin";
        public static string Teacher = "Teacher";
        public static string Student = "Student";
        public static string Moderator = "Moderator";
        public static string Passive = "Passive";

        public static List<string> Roles => new List<string>() { Admin, Passive ,Teacher,Student,Moderator};
    }
}
