using System.Collections.Generic;

namespace bidersGo.Models
{
    public static class RoleNames
    {
        public static string Admin = "Admin";
        public static string Moderator = "Moderator";
        public static string Teacher = "Teacher";
        public static string Student = "Student";
        public static string Passive = "Passive";

        public static List<string> Roles => new List<string>() { Admin, Moderator, Teacher, Student, Passive };
    }
}
