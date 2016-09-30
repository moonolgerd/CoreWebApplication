namespace CoreWebApplication.Models
{
    public class Villain
    {
        public Villain(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Role { get; set; }
    }
}