using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransferenciApi.Models;

namespace TransferenciApi.Services
{
    /// <summary>
    /// Servicio base datos clientes
    /// </summary>
    public class InformacionCliente
    {
        private readonly BaseDatosContext _dataContext;

        public InformacionCliente(BaseDatosContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Obtiene lista de clientes
        /// </summary>
        /// <returns></returns>
        public async Task<List<Cliente>> ObtenerCientes()
        {
            return await _dataContext.Clientes.ToListAsync();
        }

        /// <summary>
        /// Obtiene lista de clientes
        /// </summary>
        /// <returns></returns>
        public async Task<Cliente> ObtenerCiente(int id)
        {
            return await _dataContext.Clientes.FindAsync(id);
        }

        /// <summary>
        /// Elimina cliente
        /// </summary>
        /// <param name="idCliente">Id cliente</param>
        /// <returns>Tarea</returns>
        public async Task EliminarCiente(int idCliente)
        {
            Cliente cliente = await _dataContext.Clientes.FindAsync(idCliente);
            var res = _dataContext.Clientes.Remove(cliente);
            await _dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza cliente
        /// </summary>
        /// <param name="cliente">Cliente</param>
        /// <returns></returns>
        public async Task AgregarCiente(Cliente cliente)
        {
            _dataContext.Clientes.Add(cliente);
            await _dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza cliente
        /// </summary>
        /// <param name="cliente">Cliente</param>
        /// <returns></returns>
        public async Task ActualizarCiente(Cliente cliente)
        {
            _dataContext.Entry(cliente).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync().ConfigureAwait(true);
        }
    }
}
