using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmpty.Models.Venta
{
    public class VendedorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public UserModel Usuario { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public ICollection<VentaModel> Ventas { get; set; }
    }
}
