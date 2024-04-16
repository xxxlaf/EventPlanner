using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlanner.Models
{
    [Table("TaskItems")]
    public class TaskItem
    {
        public int TaskItemId { get; set; }
        public int EventId { get; set; }
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool Status { get; set; }
    }
}
