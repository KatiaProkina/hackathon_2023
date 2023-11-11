using System.ComponentModel.DataAnnotations;

namespace ShootScares.API.Models
{
    public class GameResultCreateModel
    {
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int Score { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}