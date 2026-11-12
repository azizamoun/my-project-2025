using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Visitor.ServiceReference1; // add the service reference to the project

namespace Visitor
{
    public partial class Products : System.Web.UI.Page
    {
        Service1Client service = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)       //is this the first time this page is Opend
                FillDataList();
            //
            //זה כדי לחזור לאותו פריט שלחצנו  עליו בדאתא ליסת 
            if (Request.QueryString["index"] != null)
                DataListProducts.SelectedIndex = int.Parse(Request.QueryString["index"].ToString());



        }

        private void FillDataList()
        {

            ProductsList productsList = service.SelectAllProducts();

            DataListProducts.DataSource = productsList;
            DataListProducts.DataBind();

        }

        public string GetImageUrl(object strFile)
        // input: Get object of type Object that represent the content of the picture from the database
        // retrun new string the contain the content of the picture after adding parts before it that help the browser view the picture that had incoded with Base64
        {
            return "data:image/jpg;base64," + strFile.ToString();
        }

        


        protected void DataListProducts_ItemCommand(object source, DataListCommandEventArgs e)
        {


            if (e.CommandName == "Details")
            {

                Response.Redirect("~/details.aspx?id=" + e.CommandArgument);
            }
            else if (e.CommandName == "AddToCart")
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("~/login.aspx?needLogin=1");
                }

                else  //the user had ben registered
                {
                    string productId = e.CommandArgument.ToString();
                    var cart = Session["cart"] as List<Product> ?? new List<Product>();
                    Service1Client service = new Service1Client();
                    Product product = service.GetProductById(productId);
                    if (product == null)
                        return;
                    cart.Add(product);
                    Session["cart"] = cart;
                }
            }
        }
    }
}