using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Visitor.ServiceReference1;

namespace Visitor
{
    public partial class login : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["needLogin"] == "1")
                Label1.Text = "You must log in before adding to the cart.";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text;
            if (username.Length == 0 || password.Length == 0)
            {
                Label1.Text = "Enter a username and a password.";
                return;
            }

            Service1Client service = new Service1Client();
            User user = service.GetUser(username, password);
            if (user != null)
            {
                Session["user"] = user;

                if (Request.QueryString["id"] != null)
                    Response.Redirect("~/details.aspx?id=" + Request.QueryString["id"]);
                else
                    Response.Redirect("~/products.aspx");
            }
            else
            {
                Label1.Text = "Wrong username or password.";
            }
        }
    }
}