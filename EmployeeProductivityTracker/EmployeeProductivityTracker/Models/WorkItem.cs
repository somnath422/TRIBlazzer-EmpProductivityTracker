public class WorkItem
{
    public int ID { get; set; }
    public string WorkItemType { get; set; }
    public string Title { get; set; }
    public string AssignedTo { get; set; }
    public string State { get; set; }
    public string IterationPath { get; set; }
    public string AreaPath { get; set; }
    public double? StoryPoints { get; set; }
    public int NumberOfCommitsPerStory { get; set; }
    public int NumberOfBugsRaised { get; set; }
    public int NumberOfReviewCommentsPerMergeRequest { get; set; }
    public int NumberOfDaysToCloseTheStory { get; set; }
    public double? BlockerTime { get; set; }
    public double? OriginalEstimateInHours { get; set; }
    public double? CompletedEstimateInHours { get; set; }
}