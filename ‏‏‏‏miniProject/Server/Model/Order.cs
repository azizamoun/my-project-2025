using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Order : BaseEntity
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string StatusOfOrder { get; set; }
        [DataMember]
        public string DateOfOrder { get; set; }
        [DataMember]
        public int TotalPrice { get; set; }




        public Order()
        {

        }

        public Order(int orderID, int userId, string statusOfOrder, string dateOfOrder, int totalPrice) : base(orderID)
        {
            this.UserId = userId;
            this.StatusOfOrder = statusOfOrder;
            this.DateOfOrder = dateOfOrder;
            this.TotalPrice = totalPrice;

        }



    }
}
