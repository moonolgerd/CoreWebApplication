using System.ComponentModel.DataAnnotations;

namespace Heroic.Shared
{
    public class Hero
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
		public string Gender { get; set; }
    }
}