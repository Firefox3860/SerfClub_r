using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SerfClub.Models
{
    public class UserViewModel : User
    {
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(20)]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6 символов")]
        [Display(Name = "Подтвердите пароль")]
        public string CheckPassword { get; set; }
    }
}
