using Core.Entities;

namespace ForestPlaces.Models.AreaModels
{
    public class CreateAreaModel
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Area ToArea()
        {
            return new Area
            {
                Name = Name,
                Longitude = Longitude,
                Latitude = Latitude,
            };
        }
    }
}
