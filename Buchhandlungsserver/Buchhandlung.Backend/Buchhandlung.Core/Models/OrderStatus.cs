using System.Drawing;

namespace Buchhandlung.Core.Models
{
    public class OrderStatus
    {
        public string StatusName { get; set; }
        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }
        public bool SendEmail { get; set; }
        public bool Delivery { get; set; }
        public bool Invoice { get; set; }
    }
}