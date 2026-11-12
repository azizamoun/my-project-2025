using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Visitor.ServiceReference1;

namespace Visitor
{
    public partial class thankYou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = Session["user"] as User;
                if (user == null)
                {
                    Response.Redirect("~/login.aspx");
                    return;
                }

                fullNameLabel.Text = user.Fname + " " + user.Lname;
                orderNumberLabel.Text = Request.QueryString["orderId"] ?? "";
                totalLabel.Text = Request.QueryString["total"] ?? "0";
                addressLabel.Text = Request.QueryString["address"] ?? "";
                DateLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
                Session["cart"] = null;
                //List<Product> cart = Session["cart"] as List<Product>;
                //cart.Clear();
            }
        }
    }
}