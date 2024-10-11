using GerenciamentoClientesAPI.Models;

namespace GerenciamentoClientesAPI.Repositories.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly List<Cliente> _clientes;

        public ClienteRepository()
        {
            _clientes = new List<Cliente>();
        }

        public async Task<List<Cliente>> ListarClientesAsync(int pagina, int tamanhoPagina)
        {
            return await Task.FromResult(_clientes
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToList());
        }

        public async Task<Cliente> ObterClientePorIdAsync(int id)
        {
            return await Task.FromResult(_clientes.FirstOrDefault(c => c.Id == id));
        }

        public async Task<int> CriarClienteAsync(Cliente cliente)
        {
            cliente.Id = _clientes.Count + 1;
            _clientes.Add(cliente);
            return await Task.FromResult(cliente.Id);
        }

        public async Task AtualizarClienteAsync(Cliente cliente)
        {
            var existing = await ObterClientePorIdAsync(cliente.Id);
            if (existing != null)
            {
                existing.CNPJ = cliente.CNPJ;
                existing.Nome = cliente.Nome;
                existing.Ativo = cliente.Ativo;
                existing.Enderecos = cliente.Enderecos;
                existing.Telefones = cliente.Telefones;
                existing.Emails = cliente.Emails;
            }
        }

        public async Task ExcluirClienteAsync(int id)
        {
            var cliente = await ObterClientePorIdAsync(id);
            if (cliente != null)
                _clientes.Remove(cliente);
        }
    }

}
