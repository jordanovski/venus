using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venus.Model
{
    public partial class Tables : IObjectsWithState
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


        [NotMapped]
        public State State { get; set; }
    }
}
