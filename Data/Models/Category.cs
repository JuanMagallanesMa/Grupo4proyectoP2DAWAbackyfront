using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; } // true = activo, false = inactivo
        public List<string> EdadesAplicables { get; set; } = new List<string>();
        public List<string> TiposEvento { get; set; } = new List<string>();

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        [JsonIgnore]
        public virtual ICollection<Promociones> Promociones { get; set; } = new List<Promociones>();
    }
}
