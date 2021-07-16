using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SerfClub.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(20)]
        [MinLength(3, ErrorMessage = "Минимальная длина псевдонима - 3 символа")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(31)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(20)]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6 символов")]
        public string Password { get; set; }

        [MaxLength(31)]
        public string LastName { get; set; }

        [MaxLength(31)]
        public string FirstName { get; set; }

        public Guid? Photo { get; set; }

        [MaxLength(255)]
        public string Contacts { get; set; }

        [MaxLength(255)]
        public string AboutMe { get; set; }

        [MaxLength(255)]
        public string Achievements { get; set; }
    }

}
