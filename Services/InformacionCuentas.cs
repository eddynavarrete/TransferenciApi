using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransferenciApi.Models;

namespace TransferenciApi.Services
{
    /// <summary>
    /// Información cuentas cuenta
    /// </summary>
    public class InformacionCuentas
    {
        private readonly BaseDatosContext _dataContext;

        public InformacionCuentas(BaseDatosContext dataContext)
        {
            _dataContext = dataContext;
        }
        /// <summary>
        /// Obtiene cuentas de clientes
        /// </summary>
        /// <returns></returns>
        public async Task<List<Cuentum>> ObtenerCuentasCientes()
        {
            return await _dataContext.Cuenta.ToListAsync();
        }

        /// <summary>
        /// Obtiene cuenta
        /// </summary>
        /// <param name="id">Id Cuenta</param>
        /// <returns>Cuenta</returns>
        public async Task<Cuentum> ObtenerCuentaCiente(int id)
        {
            return await _dataContext.Cuenta.FindAsync(id);
        }

        /// <summary>
        /// Actualiza cuenta
        /// </summary>
        /// <param name="cuenta">Cliente</param>
        /// <returns></returns>
        public async Task AgregarCuenta(Cuentum cuenta)
        {
            _dataContext.Cuenta.Add(cuenta);
            await _dataContext.SaveChangesAsync();
        }

    }
}
