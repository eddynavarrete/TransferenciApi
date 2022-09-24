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
    public class EliminarCliente : IEliminar
    {
        private readonly BaseDatosContext _dataContext;
        private readonly IRedisService _redisService;

        public EliminarCliente(BaseDatosContext dataContext, IRedisService redisService)
        {
            _dataContext = dataContext;
            _redisService = redisService;
        }
        /// <summary>
        /// Elimina cliente
        /// </summary>
        /// <param name="id">Id cliente</param>
        /// <returns>Tarea</returns>
        /// <exception cref="Exception"></exception>
        public async Task Consultar(int id)
        {
            string result = await _redisService.Obtener("Clientes");
            List<Cliente> clientes = JsonSerializer.Deserialize<List<Cliente>>(result);

            InformacionCliente conection = new InformacionCliente(_dataContext);
            Cliente clienteCache = clientes.FirstOrDefault(x => x.Id == id);
            if (clienteCache == null)
            {
                throw new Exception("Id cliento no valido");
            }
            await conection.EliminarCiente(id);
            clientes.Remove(clienteCache);
            await _redisService.Guardar("Clientes", JsonSerializer.Serialize(clientes));
        }
    }
}
