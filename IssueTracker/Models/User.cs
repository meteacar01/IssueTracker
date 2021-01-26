using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class User : BaseEntity
    { 

        [Required]
        [MaxLength(20)] 
        [Display(Name = "Kullanıcı Adı")]
        public string Name { get; set; }

        [Display(Name = "Oluşturma Zamanı")]
        public DateTime CreatedAt{ get; set; } 
    }
}
