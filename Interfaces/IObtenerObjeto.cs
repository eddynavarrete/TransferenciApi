using System.Collections.Generic;
using System.Threading.Tasks;
using TransferenciApi.Models;

namespace TransferenciApi.Interfaces
{
    public interface IObtenerObjeto
    {
        /// <summary>
        /// Interfaz de consulta
        /// </summary>
        public interface IObtener
        {
            /// <summary>
            /// Obtener
            /// </summary>
            /// <returns></returns>
            Task<List<Cliente>> Consultar(int id);
        }
    }
}
