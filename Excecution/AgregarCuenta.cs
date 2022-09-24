using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using TransferenciApi.Interfaces;
using TransferenciApi.Models;
using TransferenciApi.Services;

namespace TransferenciApi.Excecution
{
    public class AgregarCuenta : IProcesar
    {
        private readonly BaseDatosContext _dataContext;
        private readonly IRedisService _redisService;

        public AgregarCuenta(BaseDatosContext dataContext, IRedisService redisService)
        {
            _dataContext = dataContext;
            _redisService = redisService;
        }

        /// <summary>
        /// Almacena cuenta
        /// </summary>
        /// <param name="requerido"></param>
        /// <returns></returns>
        public async Task Procesar(object requerido)
        {
            List<Cuentum> clientes = new List<Cuentum>();

            Cuentum cuentas = (Cuentum)requerido;
            string result = await _redisService.Obtener("Cuentas");
            clientes = JsonSerializer.Deserialize<List<Cuentum>>(result);

            InformacionCuentas conection = new InformacionCuentas(_dataContext);

            await conection.AgregarCuenta(cuentas);
            clientes.Add(cuentas);
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

