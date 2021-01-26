using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class Comment : BaseEntity
    {

        [Required]
        [MaxLength(500)]
        [Display(Name = "Content")]
        public string Content { get; set; }

        public int CreatedBy { get; set; }


        [Display(Name = "Oluşturma Zamanı")]
        public DateTime CreatedAt { get; set; }
    }
}
