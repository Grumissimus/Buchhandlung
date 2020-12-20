using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Buchhandlung.Core.Models
{
    public class ISBN13 : ISBN
    {
        private readonly Regex format = new Regex("^[\\d-]+$");

        public ISBN13(string isbn) : base(isbn)
        {
        }

        public override void Validate(string value)
        {
            if (value.Contains('X'))
                throw new ArgumentException("The ISBN-13 contains \'X\'. Did you confuse with ISBN-10 format?");

            if (!format.IsMatch(value))
                throw new ArgumentException("The ISBN-13 contains invalid characters.");

            var digits = Regex.Replace(value, "-", "");

            if (digits.Length != 13)
                throw new ArgumentException("The ISBN-13 doesn't contain exactly thirteen digits");

            var sum = digits
                .Select(x => int.Parse(x.ToString()))
                .ToArray();

            var checkDigit = sum.Last();
            int checksum = 0;

            for(int i = 0; i < 12; i++)
            {
                checksum += (i+1) % 2 != 0 ? sum[i] : sum[i] * 3;
            }
            checksum %= 10;

            switch (checksum)
            {
                case 0:
                    if (checksum != checkDigit)
                        throw new ArgumentException($"The ISBN-13 checksum failed. Expected {checkDigit}, but got {checksum}.");
                    break;
                default:
                    if (10 - checksum != checkDigit)
                        throw new ArgumentException($"The ISBN-13 checksum failed. Expected {checkDigit}, but got {checksum}.");
                    break;
            }

        }
    }
}
