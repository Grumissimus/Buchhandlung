using Buchhandlung.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buchhandlung.Core.Models
{
    public class Order : Entity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public virtual ICollection<OrderLine> Items { get; set; }
        public OrderStatus Status { get; set; }
    }
}