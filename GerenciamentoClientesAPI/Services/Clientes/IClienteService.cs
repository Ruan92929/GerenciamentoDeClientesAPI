using GerenciamentoClientesAPI.Models;

namespace GerenciamentoClientesAPI.Services.Clientes
{
    public interface IClienteService
    {
        Task<List<Cliente>> ListarClientesAsync(int pagina, int tamanhoPagina);
        Task<Cliente> ObterClientePorIdAsync(int id);
        Task<int> CriarClienteAsync(Cliente cliente);
        Task AtualizarClienteAsync(int id, Cliente cliente);
        Task ExcluirClienteAsync(int id);
    }

}
