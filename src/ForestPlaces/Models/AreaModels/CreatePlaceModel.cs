using Core.Entities;

namespace ForestPlaces.Models.AreaModels
{
    public class CreatePlaceModel
    {
        public CreatePlaceModel()
        {
            Name = String.Empty;
            Description = String.Empty;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int AreaId { get; set; }

        public Place ToPlace()
        {
            return new Place
            {
                Name = Name,
                Description = Description,
                Longitude = Longitude,
                Latitude = Latitude,
            };
        }
    }
}
