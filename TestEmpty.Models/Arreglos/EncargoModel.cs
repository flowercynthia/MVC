using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEmpty.Models.Administracion;

namespace TestEmpty.Models.Arreglos
{
    public class EncargoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string DireccionEntrega { get; set; }
        public ArregloModel Arreglo { get; set; }

        [ForeignKey("Arreglo")]
        public int ArregloId { get; set; }
        public ClienteModel Cliente { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
    }
}
