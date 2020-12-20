using Buchhandlung.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buchhandlung.Core.Models
{
    public class Money : ValueObject
    {
        public string Currency { get; }
        public decimal Value { get; }

        public Money(string currency, decimal value)
        {
            Currency = currency;
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Currency.ToUpper();
            yield return Math.Round(Value, 2);
        }
    }
}
