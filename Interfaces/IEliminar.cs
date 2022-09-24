using System.Collections.Generic;
using System.Threading.Tasks;
using TransferenciApi.Models;

namespace TransferenciApi.Interfaces
{
    /// <summary>
    /// Intefaz elimina
    /// </summary>
    public interface IEliminar
    {
        /// <summary>
        /// Elimina
        /// </summary>
        /// <returns>Tarea</returns>
        Task Consultar(int id);
    }
}
