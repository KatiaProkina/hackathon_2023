namespace ShootScares.API.Domain.Entities
{
    public class GameResult : IEntity
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
