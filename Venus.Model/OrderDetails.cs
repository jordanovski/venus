using System.ComponentModel.DataAnnotations.Schema;

namespace Venus.Model
{
    public partial class OrderDetails : IObjectsWithState
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public float? Discount { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual Products Products { get; set; }


        [NotMapped]
        public State State { get; set; }
    }
}
