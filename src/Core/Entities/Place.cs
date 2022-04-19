namespace Core.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int CategoryId { get; set; }
        public int AreaId { get; set; }

        public Category Category { get; set; }
        public Area Area { get; set; }
    }
}
