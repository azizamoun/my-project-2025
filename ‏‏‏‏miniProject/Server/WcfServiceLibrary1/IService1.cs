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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        UsersList SelectAllUsers();

        [OperationContract]
        User[] SelectAllUsersAsArray();
        
        [OperationContract]
        User GetUser(string username, string password);
        
        [OperationContract]
        User GetUserById(string userID);

        [OperationContract]
        void InsertUser(User user);
        
        [OperationContract]
        void DeleteUser(User user);
        [OperationContract]
        void UpdateUser(User user);

//======================product=========================


        [OperationContract]
        ProductsList SelectAllProducts();

        [OperationContract]
        Product[] SelectAllProductsAsArray();


        [OperationContract]
        Product GetProductById(string productID);

        [OperationContract]
        void InsertProduct(Product product);

        [OperationContract]
        void DeleteProduct(Product product);
        [OperationContract]
        void UpdateProduct(Product product);

        [OperationContract]
        OrdersList SelectAllOrders();


        [OperationContract]
        Order GetOrderByOrderId(string orderID);

        [OperationContract]
        OrdersList SelectOrdersByUserId(string userId);

        [OperationContract]
        OrdersList SelectOrderByDate(string dateOfOrder);


        [OperationContract]

        Order SelectOrderByDateAndUserId(string dateOfOrder, int userId);
        [OperationContract]
        void InsertOrder(Order order);
        [OperationContract]
        // ======order items begin==================
        void AddProductToOrder(Order order, Product product);
        [OperationContract]
        void DeleteProductFromOrder(Order order, Product product);


        [OperationContract]
        void AddOrderItem(OrderItem item);

        //==========order item end=========================
    }


}

