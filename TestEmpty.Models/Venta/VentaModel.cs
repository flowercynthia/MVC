using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEmpty.Models.Administracion;

namespace TestEmpty.Models.Venta
{
    public class VentaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public ClienteModel Cliente { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteId{ get; set; }
        public VendedorModel Vendedor { get; set; }
        [ForeignKey("Vendedor")]
        public int VendedorId { get; set; }
        public ICollection<DetalleVentaFlorModel> DetalleVentas { get; set; }
    }
}
