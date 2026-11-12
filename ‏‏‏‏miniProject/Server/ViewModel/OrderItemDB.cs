using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ViewModel
{
    public class OrderItemDB : BaseDB
    {
        public OrderItemDB() : base() { }

        public OrderItemsList SelectAll()
        {
            PrepareCommand("SELECT * FROM TblOrderItems");
            List<BaseEntity> list = Select();
            return new OrderItemsList(list);
        }

        public OrderItemsList SelectAllByOrderId(int orderId)
        {
            PrepareCommand("SELECT * FROM TblOrderItems where colOrderId=@OrderId");
            command.Parameters.AddWithValue("@OrderId", orderId);
            List<BaseEntity> list = Select();
            OrderItemsList orderItemsList = new OrderItemsList(list);
            return orderItemsList;
        }
        protected override void CreateInsertSql(BaseEntity entity)
        {
            OrderItem orderItem = entity as OrderItem;
            string sqlStr = string.Format("insert into tblOrderItems(colOrderId,colProductId,colProductPrice) values (@OrderId, @ProductId, @ProductPrice)");

            command.CommandText = sqlStr;
            command.Parameters.AddWithValue("@OrderId", orderItem.OrderId);
            command.Parameters.AddWithValue("@ProductId", orderItem.ProductId);
            command.Parameters.AddWithValue("@ProductPrice", orderItem.ProductPrice);

        }
        protected override void CreateDeleteSql(BaseEntity entity)
        {// delete the product from the order
            OrderItem orderItem = entity as OrderItem;

            string cmdText = "DELETE * FROM TblOrderItems WHERE colProductId=@productId and colOrderId=@orderId";
            command.CommandText = cmdText;
            command.Parameters.AddWithValue("@productId", orderItem.ProductId);
            command.Parameters.AddWithValue("@orderId", orderItem.OrderId);
        }




        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            OrderItem orderItem = entity as OrderItem;
            orderItem.Id = ReadInt("index");
            orderItem.OrderId = ReadInt("ColOrderId");
            orderItem.ProductId = ReadInt("ColProductId");
            orderItem.ProductPrice = ReadInt("ColProductPrice");
            return orderItem;


        }



        protected override void CreateUpdateSql(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override BaseEntity NewEntity()
        {
            return new OrderItem();

        }
    }




}
