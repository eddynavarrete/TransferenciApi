using Newtonsoft.Json;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace TransferenciApi.Services
{
    /// <summary>
    /// Implementación de redis
    /// </summary>
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public RedisService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        /// <summary>
        /// Almacena información
        /// </summary>
        /// <param name="clave">Clave</param>
        /// <param name="valor">Valor</param>
        /// <returns>Tarea</returns>
        public async Task Guardar(string clave, string valor)
        {
            var db = _connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(clave, valor);
        }

        /// <summary>
        /// Obtiene información
        /// </summary>
        /// <param name="clave">Clave</param>
        /// <returns>String</returns>
        public async Task<string> Obtener(string clave)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(clave);
        }
    }
}
