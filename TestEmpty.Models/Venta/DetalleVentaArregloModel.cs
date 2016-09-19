using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEmpty.Models.Arreglos;

namespace TestEmpty.Models.Venta
{
    public class DetalleVentaArregloModel
    {
        public VentaModel Venta { get; set; }
        [ForeignKey("Venta")]
        public int VentaId { get; set; }
        public ArregloModel Arreglo { get; set; }
        [ForeignKey("Arreglo")]
        public int ArregloId { get; set; }
        public int Cantidad { get; set; }
    }
}
