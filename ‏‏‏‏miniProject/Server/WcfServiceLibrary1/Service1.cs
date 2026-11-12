using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using ViewModel;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public UsersList SelectAllUsers()
        {
            UserDB userDB= new UserDB();
           return  userDB.SelectAll();

        }

        public User[] SelectAllUsersAsArray()
        {
           UserDB userDB= new UserDB();
            UsersList list = userDB.SelectAll();
            if(list.Count==0)
                return null;
            User[] arr= new User[list.Count];
            int i = 0;
            foreach(User user in list)
                arr[i++] = user;
            return arr;
        }

        public User GetUser(string username, string password)
        {
            UserDB userDB = new UserDB();
            User user = userDB.GetUser(username, password);
            return user;
        }

        public User GetUserById(string userID)
        {
            UserDB userDB = new UserDB();
            User user = userDB.GetUser(userID);
            return user;

        }

        public void InsertUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            UserDB userDB = new UserDB();
            userDB.Insert(user);
            userDB.Savechanges();

        }
        public void UpdateUser(User user)
        {
            if(user == null) 
                throw new ArgumentNullException("user");
            UserDB userDB=new UserDB();
            userDB.Update(user);
            userDB.Savechanges();

        }
        public void DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            UserDB userDB = new UserDB();
            userDB.Delete(user);
            userDB.Savechanges();

        }



      public  ProductsList SelectAllProducts()
        {
            ProductDB productDB = new ProductDB();
            return productDB.SelectAll();
        }

      
        public Product[] SelectAllProductsAsArray()
        {
            ProductDB productDB = new ProductDB();
            ProductsList list = productDB.SelectAll();
            if (list.Count == 0)
                return null;
            Product[] arr = new Product[list.Count];
            int i = 0;
            foreach (Product product in list)
                arr[i++] = product;
            return arr;
        }


        public Product GetProductById(string productID)
        {
            ProductDB productDB = new ProductDB();
            Product product = productDB.GetProduct(productID);
            return product;
        }



        public void InsertProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");
            ProductDB productDB = new ProductDB();
            productDB.Insert(product);
            productDB.Savechanges();
        }

        public void DeleteProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");
            ProductDB productDB = new ProductDB();
            productDB.Delete(product);
            productDB.Savechanges();
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");
            ProductDB productDB = new ProductDB();
            productDB.Update(product);
            productDB.Savechanges();
        }

        public OrdersList SelectAllOrders()
        {
            OrderDB orderDB = new OrderDB();
            return orderDB.SelectAll();

        }

        public Order GetOrderByOrderId(string orderID)
        {
            OrderDB orderDB = new OrderDB();
            Order order = orderDB.GetOrderByOrderId(orderID);
            return order;
        }

        public OrdersList SelectOrdersByUserId(string userId)
        {
            OrderDB orderDB = new OrderDB();
            return orderDB.SelectOrdersByUserId(userId);

        }

        public OrdersList SelectOrderByDate(string dateOfOrder)
        {
            OrderDB orderDB = new OrderDB();
            return orderDB.SelectOrdersByDate(dateOfOrder);


        }

        public Order SelectOrderByDateAndUserId(string dateOfOrder, int userId)
        {
            OrderDB orderDB = new OrderDB();
            return orderDB.SelectOrderByDateAndUserId(dateOfOrder, userId);


        }



        public void InsertOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException("order");
            OrderDB orderDB = new OrderDB();
            orderDB.Insert(order);
            orderDB.Savechanges();
        }


        public void AddProductToOrder(Order order, Product product)
        {
            if (order == null)
                throw new ArgumentNullException("order");
            if (product == null)
                throw new ArgumentNullException("product");

            int price = ParsePrice(product.Price);
            OrderItemDB orderItemDB = new OrderItemDB();
            OrderItem orderItem = new OrderItem();
            orderItem.OrderId = order.Id;
            orderItem.ProductId = product.Id;
            orderItem.ProductPrice = price;
            orderItemDB.Insert(orderItem);
            orderItemDB.Savechanges();

            OrderDB orderDB = new OrderDB();
            order.TotalPrice += price;
            orderDB.Update(order);
            orderDB.Savechanges();
        }

        public void DeleteProductFromOrder(Order order, Product product)
        {
            if (order == null)
                throw new ArgumentNullException("order");
            if (product == null)
                throw new ArgumentNullException("product");

            OrderItem orderItem = new OrderItem();
            orderItem.OrderId = order.Id;
            orderItem.ProductId = product.Id;

            OrderItemDB orderItemDB = new OrderItemDB();
            orderItemDB.Delete(orderItem);
            string error = orderItemDB.Savechanges();
            if (!string.IsNullOrEmpty(error))
                return;

            int price = ParsePrice(product.Price);
            order.TotalPrice -= price;
            if (order.TotalPrice < 0)
                order.TotalPrice = 0;

            OrderDB orderDB = new OrderDB();
            orderDB.Update(order);
            orderDB.Savechanges();
        }

        private static int ParsePrice(string price)
        {
            int value;
            if (int.TryParse(price, out value))
                return value;
            return 0;
        }


        public void AddOrderItem(OrderItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            OrderItemDB orderItemDB = new OrderItemDB();
            orderItemDB.Insert(item);
            orderItemDB.Savechanges();
        }
    }
}
