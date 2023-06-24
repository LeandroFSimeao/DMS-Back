using Newtonsoft.Json;

namespace DMS.Data.Dtos
{
    public class DirectionsResultDTO
    {
        [JsonProperty("routes")]
        public List<Route> Routes { get; set; }
    }

    public class Route
    {
        [JsonProperty("legs")]
        public List<Leg> Legs { get; set; }
    }

    public class Leg
    {
        [JsonProperty("start_address")]
        public string StartAddress { get; set; }

        [JsonProperty("end_address")]
        public string EndAddress { get; set; }
    }
}
