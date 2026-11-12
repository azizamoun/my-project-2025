using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Visitor.ServiceReference1;

namespace Visitor
{
    public partial class buy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string total = Request.QueryString["total"];
                totalLabel.Text = string.IsNullOrEmpty(total) ? "0" : total;
            }
        }


        protected void BuyBtn_Click(object sender, EventArgs e)
        {
            User user = Session["user"] as User;
            if (user == null)
            {
                Response.Redirect("~/login.aspx?needLogin=1");
                return;
            }

            var cart = Session["cart"] as List<Product>;
            if (cart == null || cart.Count == 0)
            {
                Response.Redirect("~/Cart.aspx");
                return;
            }

            int totalPrice;
            if (!int.TryParse(totalLabel.Text, out totalPrice))
                totalPrice = 0;

            Order order = new Order();
            order.UserId = user.Id;
            order.StatusOfOrder = "paid";
            order.DateOfOrder = DateTime.Now.ToString("yyyy/MM/dd");
            order.TotalPrice = totalPrice;
            Service1Client service = new Service1Client();
            service.InsertOrder(order);
            Order temp = service.SelectOrderByDateAndUserId(order.DateOfOrder, user.Id);
            if (temp == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "orderError",
                    "alert('The order could not be saved. Please try again.');", true);
                return;
            }

            int ordernumber = temp.Id;
            order.Id = ordernumber;
            foreach (Product product in cart)
            {
                if (product == null)
                    continue;

                int price;
                int.TryParse(product.Price, out price);
                OrderItem orderItem = new OrderItem();
                orderItem.OrderId = ordernumber;
                orderItem.ProductId = product.Id;
                orderItem.ProductPrice = price;
                service.AddOrderItem(orderItem);
            }

            Response.Redirect("~/thankyou.aspx?orderId=" + ordernumber
                + "&total=" + order.TotalPrice
                + "&address=" + HttpUtility.UrlEncode(TextBoxAddress.Text));



        }
    }
}