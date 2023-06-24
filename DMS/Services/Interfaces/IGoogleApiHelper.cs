using DMS.Data.Dtos;

namespace DMS.Services.Interfaces
{
    public interface IGoogleApiHelper
    {
        Task<GeoCodeResponse> Geocoding(string address);
        Task<EntregaDTO> GeraRotaOtimizada(List<string> enderecos);
    }
}
