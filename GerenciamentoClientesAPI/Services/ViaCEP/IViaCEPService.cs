using GerenciamentoClientesAPI.Models;

namespace GerenciamentoClientesAPI.Services.ViaCEP
{
    public interface IViaCEPService
    {
        Task<Endereco> ConsultarEnderecoPorCEPAsync(string cep);
    }
}
