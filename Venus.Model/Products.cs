namespace Venus.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public short? UnitsInStock { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
