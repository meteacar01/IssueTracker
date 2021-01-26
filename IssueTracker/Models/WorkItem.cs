using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class WorkItem :BaseEntity
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Work Item")]
        public string Title { get; set; }

  
        public string Content { get; set; }

        public WorkItemType WorkItemType { get; set; }
        public int WorkItemTypeId { get; set; }
        public int CreatedBy { get; set; }


        [Display(Name = "Oluşturma Zamanı")]
        public DateTime CreatedAt { get; set; }

        public Iteration Iteration { get; set; }

        public int IterationId { get; set; } 
        public int AssignedTo { get; set; }

        public WorkItemState WorkItemState { get; set; }
        public int WorkItemStateId { get; set; }
    }
}
