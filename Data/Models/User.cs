using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string Role { get; set; }
        public bool IsAviable { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
