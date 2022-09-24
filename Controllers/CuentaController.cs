using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Route("cuentas")]
    public class CuentaController : Controller
    {
        private readonly BaseDatosContext _dataContext;
        private readonly IRedisService _redisService;

        public CuentaController(BaseDatosContext dataContext, IRedisService redisService)
        {
            _dataContext = dataContext;
            _redisService = redisService;
        }

        /// <summary>
        /// Obtiene las cuentas
        /// </summary>
        /// <returns>Lista cuentas</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuentum>>> Consultar()
        {
            ConsultarCuentas consultarCuentas = new ConsultarCuentas(_dataContext, _redisService);
            return await consultarCuentas.Consultar();
        }

        /// <summary>
        /// Cuenta 
        /// </summary>
        /// <param name="id">Id cuenta</param>
        /// <returns>Cuenta</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuentum>> GetCuenta(int id)
        {
            ConsultaCuenta consultaCuenta = new ConsultaCuenta(_dataContext, _redisService);
            return await consultaCuenta.Consultar(id);
        }

        /// <summary>
        /// Agrega cuenta
        /// </summary>
        /// <param name="cuenta">Cuenta</param>
        /// <returns>Tarea</returns>
        [HttpPost]
        public async Task<ActionResult<Cuentum>> PostCuenta(Cuentum cuenta)
        {
            AgregarCuenta agregarCuenta = new AgregarCuenta(_dataContext, _redisService);
            agregarCuenta.Validar(cuenta);
            await agregarCuenta.Procesar(cuenta);
            return Ok(cuenta);
        }
    }
}
