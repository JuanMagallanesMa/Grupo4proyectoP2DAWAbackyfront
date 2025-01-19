using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Order
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Address { get; set; }
        public string Provincia { get; set; }
        public decimal Total { get; set; }

        public bool isActive { get; set; }


        

        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = null!;
    }
}
