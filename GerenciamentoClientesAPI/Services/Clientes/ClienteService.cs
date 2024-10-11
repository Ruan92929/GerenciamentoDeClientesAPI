using GerenciamentoClientesAPI.Models;
using GerenciamentoClientesAPI.Repositories.Clientes;

namespace GerenciamentoClientesAPI.Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> ListarClientesAsync(int pagina, int tamanhoPagina)
        {
            return await _clienteRepository.ListarClientesAsync(pagina, tamanhoPagina);
        }

        public async Task<Cliente> ObterClientePorIdAsync(int id)
        {
            return await _clienteRepository.ObterClientePorIdAsync(id);
        }

        public async Task<int> CriarClienteAsync(Cliente cliente)
        {
            return await _clienteRepository.CriarClienteAsync(cliente);
        }

        public async Task AtualizarClienteAsync(int id, Cliente cliente)
        {
            cliente.Id = id;
            await _clienteRepository.AtualizarClienteAsync(cliente);
        }

        public async Task ExcluirClienteAsync(int id)
        {
            await _clienteRepository.ExcluirClienteAsync(id);
        }
    }

}
