using TestApp.Common.Enums;

namespace TestApp.WebClient.Models
{
    public class LocationViewModel
    {
        public string Name { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int LocationId { get; set; }

        public override string ToString()
        {
            return string.Format("('{0}', '{1}', '{2}', '{3}'),", Name, Longitude, Latitude, LocationId);
        }
    }
}