using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_no_22
{
    public class Product : IEquatable<Product>
    {
        public string Title { get; set; }

        public int Price { get; set; }

        #region Equality members

        /// <inheritdoc />
        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Title == other.Title;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((Product)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode() => (Title != null ? Title.GetHashCode() : 0);

        #endregion

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString() => Title;

        #endregion
    }
}
