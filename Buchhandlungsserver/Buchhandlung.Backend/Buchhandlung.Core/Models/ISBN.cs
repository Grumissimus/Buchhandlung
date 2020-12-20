using Buchhandlung.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Buchhandlung.Core.Models
{
    public abstract class ISBN : ValueObject
    {
        public string Value { get; private set; }

        public ISBN(string isbn)
        {
            if(isbn == null)
                throw new ArgumentException("The ISBN cannot be null.");

            Validate(isbn);
            Value = isbn;
        }

        public abstract void Validate(string value);
        public static implicit operator string(ISBN i) => i.Value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}