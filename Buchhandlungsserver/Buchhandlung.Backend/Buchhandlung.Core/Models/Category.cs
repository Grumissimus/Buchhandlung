using Buchhandlung.Core.Common;
using System.Collections.Generic;

namespace Buchhandlung.Core.Models
{
    public class Category : Entity
    {
        public string Name;

        public virtual ICollection<Category> Parents { get; set; }
        public virtual ICollection<Category> Children { get; set; }
    }
}