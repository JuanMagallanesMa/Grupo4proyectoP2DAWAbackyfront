using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public virtual Order? Order { get; set; } = null!;
        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product? Product { get; set; } = null!;
        public int Cantidad { get; set; }
        public int Subtotal { get; set; }
        public bool isActive { get; set; }

    }
}
