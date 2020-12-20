using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Buchhandlung.Core.Models
{
    public class ISBN10 : ISBN
    {
        private readonly Regex format = new Regex("^[\\dX-]+$");

        public ISBN10(string isbn) : base(isbn)
        {
        }

        public override void Validate(string value)
        {
            if (!format.IsMatch(value))
                throw new Exception("The ISBN-10 contain invalid characters.");

            var digits = Regex.Replace(value, "-", "");

            if (digits.Length != 10)
                throw new ArgumentException("The ISBN-10 doesn't contain exactly ten digits");

            var digitList = digits
                .Select(x => x == 'X' ? 10 : int.Parse(x.ToString()))
                .ToArray();

            int checksum = 0;
            for (int i = 0; i < 9; i++)
            {
                checksum += (i + 1) * digitList[i];
            }
            checksum %= 11;

            if(checksum != digitList.Last())
                throw new ArgumentException($"The ISBN-10 checksum failed. Expected {digitList.Last()}, but got {checksum}.");
        }
    }
}
