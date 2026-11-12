using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Visitor.ServiceReference1;

namespace Visitor
{
    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (string.IsNullOrEmpty(id))
                {
                    Response.Redirect("~/Products.aspx");
                    return;
                }

                Service1Client service = new Service1Client();
                Product product = service.GetProductById(id);
                if (product == null)
                {
                    Response.Redirect("~/Products.aspx");
                    return;
                }

                Labelid.Text = product.Id.ToString();
                LabelName.Text = product.Name;
                LabelPrice.Text = product.Price;
                LabelDescription.Text = product.Description;
                Image1.ImageUrl = GetImageUrl(product.ImageStr);

            }




        }

        public string GetImageUrl(object strFile)
        // input: Get object of type Object that represent the content of the picture fron the database
        // retrun new string the contain the content of the picture after adding parts before it that help the browser view the picture that had incoded with Base64
        {
            return "data:image/jpg;base64," + strFile.ToString();
        }





        protected void LinkButtonBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Products.aspx");

        }

        protected void AddToCartLinkButton_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/login.aspx?needLogin=1&id=" + Request.QueryString["id"]);
            }
            else
            {
                string id = Request.QueryString["id"];
                if (string.IsNullOrEmpty(id))
                    return;
                Service1Client service = new Service1Client();
                Product product = service.GetProductById(id);
                if (product == null)
                    return;

                var cart = Session["cart"] as List<Product> ?? new List<Product>();

                cart.Add(product);
                Session["cart"] = cart;





                //  //======================
                //                Service1Client service = new Service1Client();
                //                User user = Session["user"] as User;
                //                if (Session["order"] == null)
                //                {
                //                    Order order = new Order();
                //                    order.UserId = user.Id;
                //                    order.StatusOfOrder = "inCart";
                //                    order.DateOfOrder=DateTime.Now.ToShortDateString();
                //                    order.TotalPrice = int.Parse(product.Price);
                //                    service.InsertOrder(order);  
                //                    Order temp = service.SelectOrderByDateAndUserId(order.DateOfOrder,user.Id);  //get the number of order from access
                //                    int ordernumber = temp.Id;
                //                    order.Id= ordernumber;
                //                    service.AddProductToOrder(order, product);
                //                    Session["order"]= order;

                //                }

                //                else
                //                { 
                //                    Order order= Session["order"] as Order;
                //                    service.AddProductToOrder(order,  product);
                //                    order = service.SelectOrderByDateAndUserId(order.DateOfOrder, user.Id);
                //                    Session["order"]= order;




                //                }

                ////============================================
            }

        }
    }
}