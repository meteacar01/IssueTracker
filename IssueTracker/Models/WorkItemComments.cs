using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class WorkItemComments : BaseEntity
    {
        public WorkItem WorkItem { get; set; }
        public int WorkItemId { get; set; }
        public Comment Comment { get; set; }
        public int CommentId { get; set; }
    }
}
