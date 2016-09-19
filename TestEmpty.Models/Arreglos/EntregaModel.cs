using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmpty.Models.Arreglos
{
    public class EntregaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Comentario { get; set; }
        public string FotoUrl { get; set; }
        public EncargoModel Encargo { get; set; }
        [ForeignKey("Encargo")]
        public int EncargoId { get; set; }
    }
}
