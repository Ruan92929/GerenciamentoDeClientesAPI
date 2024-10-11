using Microsoft.EntityFrameworkCore;

namespace GerenciamentoClientesAPI.Repositories.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> ListarClientesAsync(int pagina, int tamanhoPagina)
        {
            return await _context.Clientes
                .Include(c => c.Enderecos)
                .Include(c => c.Telefones)
                .Include(c => c.Emails)
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();
        }


        public async Task<Cliente> ObterClientePorIdAsync(int id)
        {
            return await _context.Clientes
                .Include(c => c.Enderecos)
                .Include(c => c.Telefones)
                .Include(c => c.Emails)
                .FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<int> CriarClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente.Id;
        }

        public async Task AtualizarClienteAsync(Cliente cliente)
        {
            var existing = await _context.Clientes
                .Include(c => c.Enderecos)
                .Include(c => c.Telefones)
                .Include(c => c.Emails)
                .FirstOrDefaultAsync(c => c.Id == cliente.Id);

            if (existing != null)
            {
                existing.CNPJ = cliente.CNPJ;
                existing.Nome = cliente.Nome;
                existing.Ativo = cliente.Ativo;

                _context.Enderecos.RemoveRange(existing.Enderecos);
                await _context.Enderecos.AddRangeAsync(cliente.Enderecos); 

                _context.Telefones.RemoveRange(existing.Telefones); 
                await _context.Telefones.AddRangeAsync(cliente.Telefones); 

                _context.Emails.RemoveRange(existing.Emails); 
                await _context.Emails.AddRangeAsync(cliente.Emails);

                _context.Clientes.Update(existing);
                await _context.SaveChangesAsync();
            }
        }


        public async Task ExcluirClienteAsync(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Enderecos)
                .Include(c => c.Telefones)
                .Include(c => c.Emails)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente != null)
            {
                _context.Enderecos.RemoveRange(cliente.Enderecos);
                _context.Telefones.RemoveRange(cliente.Telefones);
                _context.Emails.RemoveRange(cliente.Emails);
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

    }
}
