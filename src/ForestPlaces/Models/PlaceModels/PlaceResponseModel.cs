using Core.Entities;

namespace ForestPlaces.Models.PlaceModels
{
    public class PlaceResponseModel
    {
        public PlaceResponseModel(Place place)
        {
            Id = place.Id;
            Name = place.Name;
            Description = place.Description;
            Longitude = place.Longitude;
            Latitude = place.Latitude;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Place ToPlace()
        {
            return new Place
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Longitude = Longitude,
                Latitude = Latitude
            };
        }
    }
}
