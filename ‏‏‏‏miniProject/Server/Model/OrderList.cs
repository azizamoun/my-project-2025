using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [CollectionDataContract]
    public class OrdersList : List<Order>
    {
        // A collection for the SELECT result
        public OrdersList() { }
        public OrdersList(IEnumerable<Order> list) : base(list) { }
        public OrdersList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Order>().ToList()) { }

    }
}
