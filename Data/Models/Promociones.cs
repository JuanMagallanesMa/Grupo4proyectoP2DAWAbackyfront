using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Promociones
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public int? Id_categoria { get; set; }
        
        public virtual Category? Categoria { get; set; } = null!; // Navegación a la entidad Categoria
       
        public decimal DescuentoPorcentaje { get; set; }
        
        public DateTime FechaFin { get; set; }
        public bool IsActive { get; set; }
    }
}
