namespace Venus.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Tables
    {
        public Tables()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TableNumber { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
