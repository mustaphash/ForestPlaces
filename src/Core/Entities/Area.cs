namespace Core.Entities
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
