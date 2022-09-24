using System.Collections.Generic;
using System.Threading.Tasks;
using TransferenciApi.Models;

namespace TransferenciApi.Interfaces
{
    public interface IObtenerCuentas
    {
        /// <summary>
        /// Obtener
        /// </summary>
        /// <returns></returns>
        Task<List<Cuentum>> Consultar();
    }
}
