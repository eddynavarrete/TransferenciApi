using System;
using System.Collections.Generic;

#nullable disable

namespace TransferenciApi.Models
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public string Numero { get; set; }
        public int Id { get; set; }
        public string Tipo { get; set; }
        public bool Estado { get; set; }
        public decimal Saldo { get; set; }

        public virtual Cliente IdNavigation { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
