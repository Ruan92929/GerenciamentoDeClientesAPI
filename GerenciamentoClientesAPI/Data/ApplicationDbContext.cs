using GerenciamentoClientesAPI.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoClientesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
