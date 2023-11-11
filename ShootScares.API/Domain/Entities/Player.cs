using System.ComponentModel.DataAnnotations;

namespace ShootScares.API.Domain.Entities
{
    public class Player : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public ICollection<GameResult> Results { get; set; } = new List<GameResult>();
    }
}
