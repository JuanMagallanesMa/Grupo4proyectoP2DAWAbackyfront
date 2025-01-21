using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

      
        public decimal Precio { get; set; }
        public string Imagen { get; set; } 

        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
       
        public virtual Category Category { get; set; } = null!;
        public decimal Stock { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
