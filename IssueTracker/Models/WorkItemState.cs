
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class WorkItemState : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        [Display(Name = "Work Item State (Open, Closed)")]
        public string Name { get; set; }
    }
}
