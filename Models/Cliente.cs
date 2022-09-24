using System;
using System.Collections.Generic;

#nullable disable

namespace TransferenciApi.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Contrasenia { get; set; }
        public bool Estado { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
