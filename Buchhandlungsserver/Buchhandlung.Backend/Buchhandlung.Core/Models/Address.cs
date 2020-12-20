using Buchhandlung.Core.Common;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Buchhandlung.Core.Models
{
    public class Address : ValueObject
    {
        public string City { get; private set; }
        public string Street { get; private set; }
        public string PostalCode { get; private set; }

        private Address()
        {
        }

        public Address(string city, string street, string postalCode)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("The city name is nullable or contains whitespace characters (e.g. space, tab, new line).");

            if (Regex.Match(city, $"[\x0-\x1F\x7F\x8E-\x9F]").Success)
                throw new ArgumentException("The city name contains unprintable characters.");

            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("The street is nullable or contains whitespace characters (e.g. space, tab, new line).");

            if (Regex.Match(street, $"[\x0-\x1F\x7F\x8E-\x9F]").Success)
                throw new ArgumentException("The street contains unprintable characters.");

            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("The postal code is nullable or contains whitespace characters (e.g. space, tab, new line).");

            if (Regex.Match(postalCode, $"[\x0-\x1F\x7F\x8E-\x9F]").Success)
                throw new ArgumentException("The postal code contains unprintable characters.");

            City = city;
            Street = street;
            PostalCode = postalCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
            yield return PostalCode;
        }
    }
}