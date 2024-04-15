namespace EventPlanner.Models
{
    public class Tasks
    {
        public int TaskId { get; set; }
        public int EventId { get; set; }
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool Status { get; set; }
    }
}
