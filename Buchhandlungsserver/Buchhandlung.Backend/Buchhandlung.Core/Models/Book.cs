using Buchhandlung.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Buchhandlung.Core.Models
{
    public class Book : Entity
    {
        public ISBN ISBN { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public virtual ICollection<AuthorBook> Authors { get; private set; }
        public Publisher Publisher { get; private set; }
        public short PageNumber { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string Edition { get; private set; }
        public string Binding { get; private set; }
        public Money ItemPrice { get; private set; }
        public Category Category { get; private set; }

    }
}
