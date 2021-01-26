using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class Iteration : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        [Display(Name = "Iteration")]
        public string Name { get; set; }
    }
}
