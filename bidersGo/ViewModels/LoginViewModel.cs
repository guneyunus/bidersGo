using System.ComponentModel.DataAnnotations;

namespace bidersGo.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alan boş geçilemez..")]
        public string UserName { get; set; }
        [Display(Name = "ŞİFRE:")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 karakterli olmalıdır.")]
        [Required(ErrorMessage = "Şifre alanı boş geçilemez..")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
