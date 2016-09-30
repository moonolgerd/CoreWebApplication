namespace CoreWebApplication.Models
{
    public class Hero
    {
        public Hero(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}