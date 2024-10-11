using GerenciamentoClientesAPI.Controllers;
using GerenciamentoClientesAPI.Models;
using GerenciamentoClientesAPI.Services.Clientes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GerenciamentoClientesAPI.Testes
{
    public class ClientesControllerTeste
    {
        private readonly Mock<IClienteService> _mockClienteService;
        private readonly ClientesController _clientesController;

        public ClientesControllerTeste()
        {
            _mockClienteService = new Mock<IClienteService>();
            _clientesController = new ClientesController(_mockClienteService.Object);
        }

        [Fact]
        public async Task ListarClientes_DeveRetornarListaDeClientes()
        {
            // Arrange
            var clientes = new List<Cliente> { new Cliente { Id = 1, Nome = "Cliente Teste" } };
            _mockClienteService.Setup(x => x.ListarClientesAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(clientes);

            // Act
            var resultado = await _clientesController.ListarClientes();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(resultado.Result);
            var model = Assert.IsAssignableFrom<List<Cliente>>(okObjectResult.Value);
            Assert.Single(model);
        }
    }
}
