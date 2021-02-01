using System.ComponentModel.DataAnnotations;

namespace Heroic.Shared
{
    public class Villain
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public string Role { get; set; }
    }
}