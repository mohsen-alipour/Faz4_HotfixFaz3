namespace App.EndPoint.UI.Models.Expert
{
    public class RequestListViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ServiceTitle { get; set; }
        public int ExpertUserId { get; set; }
        public int SuggestedPrice { get; set; }

        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
