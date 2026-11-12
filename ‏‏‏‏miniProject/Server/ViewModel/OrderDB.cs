using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class OrderDB : BaseDB
    {
        public OrderDB() : base()
        { }
        public OrdersList SelectAll()
        {
            PrepareCommand("SELECT * FROM tblOrders");
            List<BaseEntity> list = Select();
            return new OrdersList(list);
        }

        public Order GetOrderByOrderId(string orderID)
        {
            PrepareCommand("SELECT * FROM tblOrders WHERE colOrderID=@OrderID");
            command.Parameters.AddWithValue("@OrderID", orderID);
            List<BaseEntity> list = Select();
            OrdersList ordersList = new OrdersList(list);
            if (ordersList.Count == 1)
                return ordersList[0];
            return null;
        }

        public OrdersList SelectOrdersByUserId(string userID)
        {
            PrepareCommand("SELECT * FROM tblOrders WHERE colUserID=@UserID");
            command.Parameters.AddWithValue("@UserID", userID);
            List<BaseEntity> list = Select();
            return new OrdersList(list);
        }

        public OrdersList SelectOrdersByDate(string dateOfOrder)
        {
            PrepareCommand("SELECT * FROM tblOrders WHERE colDateOfOrder=@DateOfOrder");
            command.Parameters.AddWithValue("@DateOfOrder", dateOfOrder);
            List<BaseEntity> list = Select();
            return new OrdersList(list);
        }

        public Order SelectOrderByDateAndUserId(string dateOfOrder, int userId)
        {
            PrepareCommand("SELECT * FROM tblOrders WHERE colUserID=@UserID and colDateOfOrder=@DateOfOrder");
            command.Parameters.AddWithValue("@UserID", userId);
            command.Parameters.AddWithValue("@DateOfOrder", dateOfOrder);
            List<BaseEntity> list = Select();
            OrdersList ordersList = new OrdersList(list);
            if (ordersList.Count >= 1)
                return ordersList[ordersList.Count - 1];
            return null;
        }



        protected override BaseEntity NewEntity()
        {
            return new Order();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Order order = entity as Order;
            order.Id = ReadInt("colOrderID");
            order.UserId = ReadInt("ColUserID");
            order.StatusOfOrder = ReadText("colStatusOfOrder");
            order.DateOfOrder = ReadText("colDateOfOrder");
            order.TotalPrice = ReadInt("colTotalPrice");
            return order;
        }
        protected override void CreateInsertSql(BaseEntity entity)

        {
            Order order = entity as Order;
            string sqlStr = string.Format("insert into tblOrders(colUserID,colStatusOfOrder, colDateOfOrder, colTotalPrice) values (@UserId, @StatusOfOrder, @DateOfOrder,@TotalPrice)");

            command.CommandText = sqlStr;
            command.Parameters.AddWithValue("@UserId", order.UserId);
            command.Parameters.AddWithValue("@StatusOfOrder", order.StatusOfOrder);
            command.Parameters.AddWithValue("@DateOfOrder", order.DateOfOrder);
            command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);

        }
        protected override void CreateUpdateSql(BaseEntity entity)

        {
            Order order = entity as Order;
            string cmdText = "UPDATE TblOrders SET ";
            cmdText += " colUserID=@UserID, colStatusOfOrder = @StatusOfOrder, ";
            cmdText += " colDateOfOrder=@DateOfOrder, colTotalPrice=@TotalPrice ";
            cmdText += " WHERE colOrderID=@OrderID";
            command.CommandText = cmdText;
            command.Parameters.AddWithValue("@UserID", order.UserId);
            command.Parameters.AddWithValue("@StatusOfOrder", order.StatusOfOrder);
            command.Parameters.AddWithValue("@DateOfOrder", order.DateOfOrder);
            command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
            command.Parameters.AddWithValue("@OrderID", order.Id);
        }
        protected override void CreateDeleteSql(BaseEntity entity)

        {
            Order order = entity as Order;
            string cmdText = "DELETE * FROM TblOrders WHERE colOrderID=@ID";
            command.CommandText = cmdText;
            command.Parameters.AddWithValue("@ID", order.Id);
        }
    }
}
