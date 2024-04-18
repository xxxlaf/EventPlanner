using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlanner.Models
{
    [Table("TaskItems")]
    public class TaskItem
    {
        public int TaskItemId { get; set; }
        [Required]
        public int EventId { get; set; }
        public string? Description { get; set; }
        public DateOnly Deadline { get; set; }
        public bool Status { get; set; }
        public virtual Event? Event { get; set; }
    }
}
