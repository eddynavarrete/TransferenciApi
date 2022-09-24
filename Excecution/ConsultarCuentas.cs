using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using TransferenciApi.Interfaces;
using TransferenciApi.Models;
using TransferenciApi.Services;

namespace TransferenciApi.Excecution
{
    public class ConsultarCuentas : IObtenerCuentas
    {
        private readonly BaseDatosContext _dataContext;
        private readonly IRedisService _redisService;

        public ConsultarCuentas(BaseDatosContext dataContext, IRedisService redisService)
        {
            _dataContext = dataContext;
            _redisService = redisService;
        }

        /// <summary>
        /// Consulta cuentas 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Cuentum>> Consultar()
        {
            List<Cuentum> cuentas = new List<Cuentum>();
            string result = await _redisService.Obtener("Cuentas");
            if (string.IsNullOrEmpty(result))
            {
                InformacionCuentas conection = new InformacionCuentas(_dataContext);
                cuentas = await conection.ObtenerCuentasCientes();
                await _redisService.Guardar("Cuentas", JsonSerializer.Serialize(cuentas));
            }
            else
            {
                cuentas = JsonSerializer.Deserialize<List<Cuentum>>(result);
            }

            return cuentas;
        }
    }
}
