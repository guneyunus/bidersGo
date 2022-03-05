using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.ModeratorCreate
{
     public   class ModeratorCreateCommandRequest:IRequest<ModeratorCreateCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public string TcKimlik { get; set; }
        [Display(Name = "ŞİFRE:")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 karakterli olmalıdır.")]
        [Required(ErrorMessage = "Şifre alanı boş geçilemez..")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ŞİFRE TEKRAR:")]
        [Required(ErrorMessage = "Şifre tekrar alanı gereklidir.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}
