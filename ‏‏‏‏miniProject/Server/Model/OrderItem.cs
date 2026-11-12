using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class OrderItem : BaseEntity
    {
        [DataMember]
        public int Index { get; set; }
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int ProductPrice { get; set; }


        public OrderItem()
        { }
        public OrderItem(int index, int orderId, int productId, int productPrice) : base(index)
        {

            OrderId = orderId;
            ProductId = productId;
            ProductPrice = productPrice;
        }

    }
}
