using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEmpty.Models.Arreglos;
using TestEmpty.Models.Venta;

namespace TestEmpty.Models.Administracion
{
    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CodCliente { get; set; }

        public ICollection<VentaModel> Ventas { get; set; }
        public ICollection<ArregloModel> Arreglos { get; set; }
    }
}
