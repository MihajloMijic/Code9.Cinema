namespace Code9.Domain.Models
{
    public class Cinema
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int NumberOfAuditoriums { get; set; }

        public Cinema() { }

        public Cinema(string name, string city, string street, int numberOfAuditoriums)
        {
            Id = Guid.NewGuid();
            Name = name;
            City = city;
            Street = street;
            NumberOfAuditoriums = numberOfAuditoriums;
        }
    }
}

