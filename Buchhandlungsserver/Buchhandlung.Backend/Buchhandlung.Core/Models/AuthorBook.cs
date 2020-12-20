using System;
using System.Collections.Generic;
using System.Text;

namespace Buchhandlung.Core.Models
{
    public class AuthorBook
    {
        public int AuthorId { get; private set; }
        public Author Author { get; private set; }
        public int BookId { get; private set; }
        public Book Book { get; private set; }
    }
}
