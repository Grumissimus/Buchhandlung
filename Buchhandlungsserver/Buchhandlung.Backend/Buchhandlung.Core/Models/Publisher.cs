using Buchhandlung.Core.Common;
using System;
using System.Collections.Generic;

namespace Buchhandlung.Core.Models
{
    public class Publisher : Entity
    {
        public string Name { get; set; }
        public string Description { get; private set; }
        public short FoundingYear { get; private set; }
        public string Website { get; private set; }
        public virtual ICollection<Book> Books { get; private set; }
    }
}
