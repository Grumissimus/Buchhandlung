using System;
using System.Collections.Generic;
using System.Text;

namespace Buchhandlung.Core.Models
{
    public class CategoryNode
    {
        public int ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public int ChildId { get; set; }
        public virtual Category Child { get; set; }
    }
}
