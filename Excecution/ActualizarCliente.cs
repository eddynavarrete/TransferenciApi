using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using TransferenciApi.Interfaces;
using TransferenciApi.Models;
using TransferenciApi.Services;
using System.Text.Json;
using System.Linq;

namespace TransferenciApi.Excecution
{
    public class ActualizarCliente : IProcesar
    {
        private readonly BaseDatosContext _dataContext;
        private readonly IRedisService _redisService;

        public ActualizarCliente(BaseDatosContext dataContext, IRedisService redisService)
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
            Cliente clienteCache = clientes.FirstOrDefault(x => x.Id == cliente.Id);
            if (cliente == null)
            {
                throw new Exception("Id cliento no valido");
            }
            await conection.ActualizarCiente(cliente);
            clientes.Remove(clienteCache);
            clientes.Add(cliente);
            await _redisService.Guardar("Clientes", JsonSerializer.Serialize(clientes));
        }

        public void Validar(object requerido)
        {
            Cliente cliente = (Cliente)requerido;
            ValidarCliente.ValidarClienteInformacion(cliente);
        }
    }
}
