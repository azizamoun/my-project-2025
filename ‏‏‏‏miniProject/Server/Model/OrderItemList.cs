using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [CollectionDataContract]
    public class OrderItemsList : List<OrderItem>
    {
        public OrderItemsList() { }

        public OrderItemsList(IEnumerable<OrderItem> list) : base(list) { }
        public OrderItemsList(IEnumerable<BaseEntity> list)
            : base(list.Cast<OrderItem>().ToList()) { }




    }
}
