namespace GerenciamentoClientesAPI.Repositories.Clientes
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ListarClientesAsync(int pagina, int tamanhoPagina);
        Task<Cliente> ObterClientePorIdAsync(int id);
        Task<int> CriarClienteAsync(Cliente cliente);
        Task AtualizarClienteAsync(Cliente cliente);
        Task ExcluirClienteAsync(int id);
    }

}
