using System.Threading.Tasks;

namespace TransferenciApi.Interfaces
{
    /// <summary>
    /// Procesa actualización
    /// </summary>
    public interface IProcesar
    {
        /// <summary>
        /// Procesa función
        /// </summary>
        /// <param name="requerido"></param>
        /// <returns></returns>
        Task Procesar(object requerido);

        /// <summary>
        /// Valida datos de entrada
        /// </summary>
        /// <param name="requerido"></param>
        void Validar(object requerido);
    }
}
