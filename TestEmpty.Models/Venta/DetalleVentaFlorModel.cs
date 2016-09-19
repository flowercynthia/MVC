using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEmpty.Models.Inventario;

namespace TestEmpty.Models.Venta
{
    public class DetalleVentaFlorModel
    {
        public VentaModel Venta { get; set; }
        [ForeignKey("Venta")]
        public int VentaId { get; set; }
        public FlorModel Flor { get; set; }
        [ForeignKey("Flor")]
        public int FlorId { get; set; }
        public int Cantidad { get; set; }
    }
}
