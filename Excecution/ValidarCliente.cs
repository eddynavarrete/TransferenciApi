using System;
using TransferenciApi.Models;

namespace TransferenciApi.Excecution
{
    /// <summary>
    /// Valida cliente
    /// </summary>
    public class ValidarCliente
    {
        /// <summary>
        /// Valida datos del cliente
        /// </summary>
        /// <param name="cliente">Cliente</param>
        /// <exception cref="Exception"></exception>
        public static void ValidarClienteInformacion(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                throw new Exception("Nombre del cliente requerido");
            }
            if (string.IsNullOrEmpty(cliente.Genero))
            {
                throw new Exception("Genero del cliente requerido");
            }
            if (cliente.Edad <= 0)
            {
                throw new Exception("Edad del cliente requerido");
            }

            if (string.IsNullOrEmpty(cliente.Contrasenia))
            {
                throw new Exception("Contrasenia del cliente requerido");
            }
            if (string.IsNullOrEmpty(cliente.Telefono))
            {
                throw new Exception("Telefono del cliente requerido");
            }
            if (string.IsNullOrEmpty(cliente.Direccion))
            {
                throw new Exception("Direccion del cliente requerido");
            }

        }

        public static void ValidarInformacionEliminacion(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id cliento no valido");
            }
        }
    }
}