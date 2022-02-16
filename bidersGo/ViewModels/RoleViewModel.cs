using System.ComponentModel.DataAnnotations;

namespace bidersGo.ViewModels
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Rolü boş geçmeyiniz.")]
        [Display(Name = "Rol Adı")]
        public string Name { get; set; }
    }
}
