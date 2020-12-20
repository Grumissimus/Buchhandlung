using System;
using System.Collections.Generic;
using System.Text;

namespace Buchhandlung.Core.Common
{
    /// <summary>
    /// A base class for entity object
    /// </summary>
    // The code comes from: https://enterprisecraftsmanship.com/posts/entity-base-class/
    public abstract class Entity
    {
        private int _id;

        public int Id
        {
            get => _id;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The identifier cannot be a negative number.");
                }

                _id = value;
            }
        }

        protected virtual object Actual => this;

        public override bool Equals(object obj)
        {
            if (!(obj is Entity that)) return false;
            if (that.Actual.GetType() != this.Actual.GetType()) return false;
            if (this.Id == 0 || that.Id == 0) return false;

            return ReferenceEquals(this, that);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (Actual.GetType().ToString() + Id).GetHashCode();
        }
    }
}
