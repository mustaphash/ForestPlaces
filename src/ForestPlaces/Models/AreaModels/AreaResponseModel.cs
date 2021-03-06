using Core.Entities;
using ForestPlaces.Models.PlaceModels;

namespace ForestPlaces.Models.AreaModels
{
    public class AreaResponseModel
    {
        public AreaResponseModel(Area area)
        {
            Id = area.Id;
            Name = area.Name;
            Longitude = area.Longitude;
            Latitude = area.Latitude;
            Places = area.Places.Select(p => new PlaceResponseModel(p));
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public IEnumerable<PlaceResponseModel> Places { get; set; }
    }
}
