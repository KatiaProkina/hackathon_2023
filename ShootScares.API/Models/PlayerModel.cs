namespace ShootScares.API.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<GameResultModel> Results { get; set; } = new List<GameResultModel>();
    }
}
