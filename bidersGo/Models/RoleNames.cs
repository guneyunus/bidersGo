﻿using System.Collections.Generic;

namespace bidersGo.Models
{
    public class RoleNames
    {
        public static string Admin = "Admin";
        public static string User = "User";
        public static string Passive = "Passive";

        public static List<string> Roles => new List<string>() { Admin, User, Passive };
    }
}
