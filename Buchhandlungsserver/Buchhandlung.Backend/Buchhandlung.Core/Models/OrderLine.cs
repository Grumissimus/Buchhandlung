namespace Buchhandlung.Core.Models
{
   public class OrderLine
   {
        public Book Item { get; set; }
        public int Stock { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}