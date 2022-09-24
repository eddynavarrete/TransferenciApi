using System;
using System.Collections.Generic;

#nullable disable

namespace TransferenciApi.Models
{
    public partial class Movimiento
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal MovimientoValor { get; set; }
        public decimal SaldoActual { get; set; }

        public virtual Cuentum NumeroNavigation { get; set; }
    }
}
