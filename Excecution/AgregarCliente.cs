using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using TransferenciApi.Interfaces;
using TransferenciApi.Models;
using TransferenciApi.Services;
using System.Text.Json;

namespace TransferenciApi.Excecution
{
    public class AgregarCliente : IProcesar
    {
        private readonly BaseDatosContext _dataContext;
        private readonly IRedisService _redisService;

        public AgregarCliente(BaseDatosContext dataContext, IRedisService redisService)
        {
            _dataContext = dataContext;
            _redisService = redisService;
        }
        public async Task Procesar(object requerido)
        {
            List<Cliente> clientes = new List<Cliente>();

            Cliente cliente = (Cliente)requerido;
            string result = await _redisService.Obtener("Clientes");
            clientes = JsonSerializer.Deserialize<List<Cliente>>(result);

            InformacionCliente conection = new InformacionCliente(_dataContext);
            
            await conection.AgregarCiente(cliente);
            clientes.Add(cliente);
            await _redisService.Guardar("Clientes", JsonSerializer.Serialize(clientes));
        }

        /// <summary>
        /// Valida datos cliente
        /// </summary>
        /// <param name="requerido">Objeto cliente</param>
        public void Validar(object requerido)
        {
            Cliente cliente = (Cliente)requerido;
            ValidarCliente.ValidarClienteInformacion(cliente);
        }
    }
}
