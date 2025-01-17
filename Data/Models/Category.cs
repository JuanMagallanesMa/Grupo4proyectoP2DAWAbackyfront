﻿using System;
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

       
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        [JsonIgnore]
        public virtual ICollection<Promociones> Promociones { get; set; } = new List<Promociones>();
    }
}
