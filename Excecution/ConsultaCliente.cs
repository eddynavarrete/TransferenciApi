using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TransferenciApi.Interfaces;
using TransferenciApi.Models;
using TransferenciApi.Services;

namespace TransferenciApi.Excecution
{
    public class ConsultaCliente : IObtenerObjeto
    {
        private readonly BaseDatosContext _dataContext;
        private readonly IRedisService _redisService;

        public ConsultaCliente(BaseDatosContext dataContext, IRedisService redisService)
        {
            _dataContext = dataContext;
            _redisService = redisService;
        }

        /// <summary>
        /// Consulta clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        public async Task<Cliente> Consultar(int id)
        {
            Cliente cliente = new Cliente();
            string result = await _redisService.Obtener("Clientes");
            if (string.IsNullOrEmpty(result))
            {
                InformacionCliente conection = new InformacionCliente(_dataContext);
                cliente = await conection.ObtenerCiente(id);
            }
            else
            {
                List<Cliente> clientes = JsonSerializer.Deserialize<List<Cliente>>(result);
                cliente = clientes.FirstOrDefault(x => x.Id == id);
            }

            return cliente;
        }
    }
}
