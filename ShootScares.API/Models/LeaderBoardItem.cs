namespace ShootScares.API.Models
{
    public class LeaderBoardItem
    {
        public string Username { get; set; } = string.Empty;
        public int Score { get; set; }
        public string Date { get; set; } = string.Empty;
    }
}
