using System.ComponentModel.DataAnnotations;

namespace ShootScares.API.Models
{
    public class PlayerCreateModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
