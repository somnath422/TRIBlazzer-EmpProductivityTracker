namespace EmployeeProductivityTracker.Models
{
    public class DashboardModel
    {
        public List<string> Teams { get; set; } = new List<string>();
        public List<string> Sprints { get; set; } = new List<string>();
        public List<string> Assignes { get; set; } = new List<string>();
        public List<string> Types { get; set; } = new List<string>();
        public List<WorkItem> WorkItems { get; set; } = new List<WorkItem>();
        public IEnumerable<dynamic> CommitsPerStory { get; set; }
    }
}
