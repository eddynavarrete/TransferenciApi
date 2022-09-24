using System.Collections.Generic;
using System.Threading.Tasks;
using TransferenciApi.Models;

namespace TransferenciApi.Interfaces
{
    public interface IObtenerCuenta
    {
        /// <summary>
        /// Obtener
        /// </summary>
        /// <returns></returns>
        Task<Cuentum> Consultar(int id);
    }
}
