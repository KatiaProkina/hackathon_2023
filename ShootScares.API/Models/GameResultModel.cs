using System.ComponentModel.DataAnnotations;

namespace ShootScares.API.Models
{
    public class GameResultModel
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int Score { get; set; }
        public string Date { get; set; } = string.Empty;
    }
}
