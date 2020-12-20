using Buchhandlung.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buchhandlung.Core.Models
{
    public class Customer : Entity
    {
        public string UserId { get; private set; }
        public string Forname { get; private set; }
        public string Surname { get; private set; }
        public Address Address { get; private set; }
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
