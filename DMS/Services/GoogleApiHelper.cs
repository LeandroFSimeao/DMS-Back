using DMS.Data.Dtos;
using DMS.Services.Interfaces;
using Newtonsoft.Json;

namespace DMS.Services
{
    public class GoogleApiHelper : IGoogleApiHelper
    {
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;

        public GoogleApiHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiKey = _configuration.GetSection("apiKey").Value;
        }

        public async Task<EntregaDTO> GeraRotaOtimizada(List<string> enderecos)
        {
            string origin = _configuration.GetSection("origem").Value;
            EntregaDTO entregaDTO = new EntregaDTO();

            using (HttpClient client = new HttpClient())
            {
                string destinationsString = string.Join("|", enderecos);
                string url = $"https://maps.googleapis.com/maps/api/directions/json?origin={Uri.EscapeDataString(origin)}&destination={Uri.EscapeDataString(origin)}&waypoints={Uri.EscapeDataString(destinationsString)}&key={_apiKey}&optimize=true";
                

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserializar a resposta JSON
                    var directionsResult = JsonConvert.DeserializeObject<DirectionsResultDTO>(jsonResponse);

                    // Obter a rota otimizada
                    var optimizedRoute = directionsResult.routes[0];

                    entregaDTO.Polyline = optimizedRoute.overview_polyline.points;

                    // Processar a rota otimizada
                    foreach (var step in optimizedRoute.legs)
                    {
                        entregaDTO.Duracao += step.duration.value;
                        entregaDTO.Distancia += step.distance.value;
                    }

                    entregaDTO.Motorista = "Carlos";
                    entregaDTO.Veiculo = "FRT3490";
                }
                else
                {
                    Console.WriteLine("Erro na solicitação: " + response.StatusCode);
                }
            }

            return entregaDTO;
        }

        public async Task<GeoCodeResponse> Geocoding(string address)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={_apiKey}";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        GeoCodeResponse dtoResponse = JsonConvert.DeserializeObject<GeoCodeResponse>(jsonResponse);
                        return dtoResponse;
                    }
                    else
                    {
                        throw new Exception("Erro ao gecodificar");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
