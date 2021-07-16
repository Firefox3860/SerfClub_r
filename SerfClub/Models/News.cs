using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SerfClub.Models
{
    [Table("News")]
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public Guid? Photo { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
        public string CreateDateLabel => CreateDate.Date.ToString("dd.MM.yyyy") + " в " + CreateDate.ToString("HH:mm");
    }

}
