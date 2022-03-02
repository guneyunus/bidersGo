using bidersGo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.TeacherCreate
{
  public  class TeacherCreateCommandRequest:IRequest<TeacherCreateCommandResponse>
    {
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alan boş geçilemez..")]
        public string UserName { get; set; }

        [Display(Name = "AD:")]
        [StringLength(50)]
        [Required(ErrorMessage = "Ad alanı boş geçilemez..")]
        public string Name { get; set; }
        [Display(Name = "SOYAD:")]
        [StringLength(50)]
        [Required(ErrorMessage = "Soyad alanı boş geçilemez..")]
        public string Surname { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email alanı boş geçilemez..")]
        public string Email { get; set; }
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

        [Display(Name = "Öğretmenin Branşı")]
        [StringLength(50)]
        public string? Branch { get; set; }
        public string TcKimlik { get; set; }
        public string NickName { get; set; }
        public string State { get; set; }
        public Guid LessonId { get; set; }
        public string RoleForRegister { get; set; }

    }
}
