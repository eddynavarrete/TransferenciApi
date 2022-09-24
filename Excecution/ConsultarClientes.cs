using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using TransferenciApi.Interfaces;
using TransferenciApi.Models;
using TransferenciApi.Services;

namespace TransferenciApi.Excecution
{
    /// <summary>
    /// Lógica de negocio
    /// </summary>
    public class ConsultarClientes : IObtener
    {
        private readonly BaseDatosContext _dataContext;
        private readonly IRedisService _redisService;

        public ConsultarClientes(BaseDatosContext dataContext, IRedisService redisService)
        {
            _dataContext = dataContext;
            _redisService = redisService;
        }

        /// <summary>
        /// Consulta clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        public async Task<List<Cliente>> Consultar()
        {
            List<Cliente> clientes = new List<Cliente>();
            string result = await _redisService.Obtener("Clientes");
            if (string.IsNullOrEmpty(result))
            {
                InformacionCliente conection = new InformacionCliente(_dataContext);
                clientes = await conection.ObtenerCientes();
                await _redisService.Guardar("Clientes", JsonSerializer.Serialize(clientes));
            }
            else
            {
                clientes = JsonSerializer.Deserialize<List<Cliente>>(result);
            }

            return clientes;
        }
    }
}
