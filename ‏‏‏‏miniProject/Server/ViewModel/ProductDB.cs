using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Model;

namespace ViewModel
{
    public class ProductDB:BaseDB
    {
        public ProductDB() : base()
        { }
        public ProductsList SelectAll()
        {
            PrepareCommand("SELECT * FROM TblProducts");
            List<BaseEntity> list = Select();
            return new ProductsList(list);
        }

        public Product GetProduct(string productID)
        {
            PrepareCommand("SELECT * FROM TblProducts WHERE ID=@ProductID");
            command.Parameters.AddWithValue("@ProductID", productID);
            List<BaseEntity> list = Select();
            ProductsList productsList = new ProductsList(list);
            if (productsList.Count == 1)
                return productsList[0];
            return null;
        }
        protected override BaseEntity NewEntity()
        {
            return new Product();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Product product = entity as Product;
            product.Id = ReadInt("ID");
            product.Name = ReadText("ColName");
            product.Description = ReadText("ColDescription");
            product.Price = ReadText("ColPrice");
            product.Quantity = ReadText("ColQuantity");
            product.ImageName = ReadText("ColImageName");
            product.ImageStr = ReadText("ColImageStr");
            product.Color = ReadText("ColColor");
            product.Hand = ReadText("ColHand");
            return product;
        }
        protected override void CreateInsertSql(BaseEntity entity)
                                                
        {
            Product product = entity as Product;
            string sqlStr = string.Format("insert into tblProducts(colName,ColDescription,ColPrice, ColQuantity, ColImageName, ColImageStr,ColColor,ColHand) values (@Name, @Description, @Price, @Quantity,@ImageName, @ImageStr,@Color,@Hand)"); 
                                         
            command.CommandText = sqlStr;
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Description",product.Description);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.Parameters.AddWithValue("@ImageName", product.ImageName);
            command.Parameters.AddWithValue("@ImageStr", product.ImageStr);
            command.Parameters.AddWithValue("@Color", product.Color);
            command.Parameters.AddWithValue("@Hand", product.Hand);
        }
        protected override void CreateUpdateSql(BaseEntity entity)
                                                
        {
            Product product = entity as Product;
            string cmdText = "UPDATE TblProducts SET ";
            cmdText += " ColName=@Name, ColDescription=@Description, ColPrice = @Price,ColColor=@Color,ColHand=@Hand ,";
            cmdText += " ColQuantity=@Quantity, ColImageName=@ImageName, ColImageStr = @ImageStr ";
            cmdText += " WHERE ID=@ID";
            command.CommandText = cmdText;
            // OleDb matches parameters by position, in the same order as the SQL.
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Color", product.Color);
            command.Parameters.AddWithValue("@Hand", product.Hand);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.Parameters.AddWithValue("@ImageName", product.ImageName);
            command.Parameters.AddWithValue("@ImageStr", product.ImageStr);
            command.Parameters.AddWithValue("@ID", product.Id);
        }
        protected override void CreateDeleteSql(BaseEntity entity)
                                                
        {
            Product product = entity as Product;
            string cmdText = "DELETE * FROM TblProducts WHERE ID=@ID";
            command.CommandText = cmdText;
            command.Parameters.AddWithValue("@ID", product.Id);
        }
    }
}

