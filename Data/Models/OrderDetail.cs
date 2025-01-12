﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Cantidad { get; set; }
        public int Subtotal { get; set; }
        public bool isActive { get; set; }

    }
}
