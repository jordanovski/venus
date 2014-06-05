using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venus.Model
{
    public partial class Orders : IObjectsWithState
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }

        public int TableId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual Tables Tables { get; set; }


        [NotMapped]
        public State State { get; set; }
    }
}
