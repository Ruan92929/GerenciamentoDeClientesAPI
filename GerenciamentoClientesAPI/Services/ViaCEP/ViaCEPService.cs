using System.Text.Json;

namespace GerenciamentoClientesAPI.Services.ViaCEP
{
    public class ViaCEPService : IViaCEPService
    {
        private readonly HttpClient _httpClient;

        public ViaCEPService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://viacep.com.br/");
        }

        public async Task<Endereco> ConsultarEnderecoPorCEPAsync(string cep)
        {
            var response = await _httpClient.GetAsync($"/ws/{cep}/json/");
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var endereco = await JsonSerializer.DeserializeAsync<Endereco>(responseStream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return endereco;
            }
            return null;
        }
    }
}
