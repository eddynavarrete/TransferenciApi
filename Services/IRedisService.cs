using System.Threading.Tasks;

namespace TransferenciApi.Services
{
    /// <summary>
    /// Interfaz de servicio redis
    /// </summary>
    public interface IRedisService
    {
        /// <summary>
        /// Almacenar información en redis
        /// </summary>
        /// <param name="clave">Clave</param>
        /// <param name="valor">Valor</param>
        /// <returns>Tarea</returns>
        Task Guardar(string clave, string valor);

        /// <summary>
        /// Obtener información de redis
        /// </summary>
        /// <param name="clave">Clave</param>
        /// <returns>String</returns>
        Task<string> Obtener(string clave);
    }
}
