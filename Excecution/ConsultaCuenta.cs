using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TransferenciApi.Interfaces;
using TransferenciApi.Models;
using TransferenciApi.Services;

namespace TransferenciApi.Excecution
{
    public class ConsultaCuenta : IObtenerCuenta
    {
        private readonly BaseDatosContext _dataContext;
        private readonly IRedisService _redisService;

        public ConsultaCuenta(BaseDatosContext dataContext, IRedisService redisService)
        {
            _dataContext = dataContext;
            _redisService = redisService;
        }

        /// <summary>
        /// Consulta cuenta
        /// </summary>
        /// <param name="id">Id cuenta</param>
        /// <returns>Cuenta</returns>
        public async Task<Cuentum> Consultar(int id)
        {
            Cuentum cuenta = new Cuentum();
            string result = await _redisService.Obtener("Cuentas");
            if (string.IsNullOrEmpty(result))
            {
                InformacionCuentas conection = new InformacionCuentas(_dataContext);
                cuenta = await conection.ObtenerCuentaCiente(id);
            }
            else
            {
                List<Cuentum> cuentas = JsonSerializer.Deserialize<List<Cuentum>>(result);
                cuenta = cuentas.FirstOrDefault(x => x.Id == id);
            }

            return cuenta;
        }
    }
}
