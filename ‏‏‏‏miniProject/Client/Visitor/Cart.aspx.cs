using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Visitor.ServiceReference1;

namespace Visitor
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTheGridView();
            }

        }
        public void BindTheGridView()
        {
            var cart = Session["cart"] as List<Product> ?? new List<Product>();
            GridView1.DataSource = cart;
            GridView1.DataBind();

            int total = 0;
            foreach (Product product in cart)
            {
                int price;
                if (product != null && int.TryParse(product.Price, out price))
                    total += price;
            }

            Label1.Font.Size = FontUnit.Larger;
            Label1.Text = total.ToString();
        }



        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var cart = Session["cart"] as List<Product>;
            if (cart == null || e.RowIndex < 0 || e.RowIndex >= cart.Count)
                return;

            cart.RemoveAt(e.RowIndex);
            Session["cart"] = cart;
            BindTheGridView();

        }


        public string GetImageUrl(object strFile)
        // input: Get object of type Object that represent the content of the picture from the database
        // retrun new string the contain the content of the picture after adding parts before it that help the browser view the picture that had incoded with Base64
        {
            return "data:image/jpg;base64," + strFile.ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            if (Session["cart"] != null)
            {
                Response.Redirect("~/buy.aspx?total=" + Label1.Text);
            }

        }
    }
}