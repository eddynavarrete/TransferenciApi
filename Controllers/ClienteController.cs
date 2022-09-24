using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransferenciApi.Excecution;
using TransferenciApi.Models;
using TransferenciApi.Services;

namespace TransferenciApi.Controllers
{
    /// <summary>
    /// Controlador cliente
    /// </summary>
    [ApiController]
    [Route("cliente")]
    public class ClienteController : Controller
    {
        private readonly BaseDatosContext _dataContext;
        private readonly IRedisService _redisService;

        public ClienteController(BaseDatosContext dataContext, IRedisService redisService)
        {
            _dataContext = dataContext;
            _redisService = redisService;
        }

        /// <summary>
        /// Consultar clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> ConsultarClientes()
        {
            ConsultarClientes consultar = new ConsultarClientes(_dataContext, _redisService);

            return Ok(await consultar.Consultar());
        }

        /// <summary>
        /// Obtener cliente por id
        /// </summary>
        /// <param name="id">Id cliente</param>
        /// <returns>Cliente</returns>
        [HttpGet("{id}")]
        public async Task<Cliente> ConsultarClienteId(int id)
        {
            ConsultaCliente consultar = new ConsultaCliente(_dataContext, _redisService);
            return await consultar.Consultar(id);
        }

        /// <summary>
        /// Agrega cliente
        /// </summary>
        /// <param name="cliente">Cliente</param>
        /// <returns>Tarea</returns>
        [HttpPost]
        public async Task<ActionResult<Cliente>> AgregarCliente(Cliente cliente)
        {
            AgregarCliente agregar = new AgregarCliente(_dataContext, _redisService);
            agregar.Validar(cliente);
            await agregar.Procesar(cliente);

            return cliente;
        }

      
        /// <summary>
        /// Elimina cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePCliente(int id)
        {
            EliminarCliente eliminarCliente = new EliminarCliente(_dataContext, _redisService);
            await eliminarCliente.Consultar(id);

            return NoContent();
        }

        /// <summary>
        /// Edita datos del cliente
        /// </summary>
        /// <param name="cliente">Cliente</param>
        /// <param name="id">Id Cliente</param>
        /// <returns>OK</returns>
        [HttpPut()]
        public async Task<IActionResult> ModificarCliente( Cliente cliente)
        {
            ActualizarCliente actualizarCliente = new ActualizarCliente(_dataContext, _redisService);
            actualizarCliente.Validar(cliente);
            await actualizarCliente.Procesar(cliente);
            return Ok();
        }

    }
}
