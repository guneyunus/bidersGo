using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using bidersGo.Domain.Common;

namespace bidersGo.Domain.Entities
{
    public class Student:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TcKimlik { get; set; }
        public Address Address { get; set; }
        public List<Meet> Meets { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsSearchLesson { get; set; }
        public Guid SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
       
    }
}
