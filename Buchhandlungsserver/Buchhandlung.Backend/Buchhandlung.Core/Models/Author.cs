using Buchhandlung.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buchhandlung.Core.Models
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<AuthorBook> Books { get; private set; }
    }
}
