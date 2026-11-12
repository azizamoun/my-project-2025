using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        public UserDB() : base() { }

        protected override BaseEntity NewEntity()
        {
            return new User();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.Id = ReadInt("colUserID");
            user.Fname = ReadText("colFName");
            user.Lname = ReadText("colLName");
            user.UserName = ReadText("colUserName");
            user.Password = ReadText("colPassword");
            user.EmailAddress = ReadText("colEmailAddress");
            user.UserType = ReadText("colUserType");
            return user;


        }
        protected override void CreateInsertSql(BaseEntity entity)
        {
           User user= entity as User;
            string sqlStr = string.Format("insert into tblUsers(colFName,colLName,colUserName," +
                                          "colPassword,colEmailAddress,colUserType) values" +
                                          " (@FName,@LName,@UserName,@Password,@EmailAddress,@UserType)");
            command.CommandText = sqlStr;
            command.Parameters.AddWithValue("@FName", user.Fname);
            command.Parameters.AddWithValue("@LName", user.Lname);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
            command.Parameters.AddWithValue("@UserType", user.UserType);


        }


        protected override void CreateUpdateSql(BaseEntity entity)
        {
            User user=entity as User;
            string sqlStr = "update tblUsers set colFName=@FName, colLName=@LName,colUserName=@userName,colPassword=@password,colEmailAddress=@emailAddress,colUserType=@userType where colUserID=@userId";
            command.CommandText = sqlStr;
            command.Parameters.AddWithValue("@FName",user.Fname);
            command.Parameters.AddWithValue("@LName", user.Lname); 
            command.Parameters.AddWithValue("@userName", user.UserName); 
            command.Parameters.AddWithValue("@password", user.Password); 
            command.Parameters.AddWithValue("@emailAddress", user.EmailAddress);
            command.Parameters.AddWithValue("@userType", user.UserType);
            command.Parameters.AddWithValue("@userId", user.Id);




        }
        protected override void CreateDeleteSql(BaseEntity entity)
        {
           User user = entity as User;
            string sqlStr = "delete * from tblUsers where colUserID=@userID";
            command.CommandText= sqlStr;
            command.Parameters.AddWithValue("@userID", user.Id);
        }

        public UsersList SelectAll()
        {
            PrepareCommand("select * from tblUsers");
            List<BaseEntity> list = Select();
            return new UsersList(list);
        }

        public User GetUser(string username, string password)
        {
            PrepareCommand("select * From tblUsers where colUserName=@UserName and colPassword=@Password");
            command.Parameters.AddWithValue("@UserName", username);
            command.Parameters.AddWithValue("@Password", password);
            List<BaseEntity> list = Select();
            UsersList usersList = new UsersList(list);
            if(usersList.Count ==1)
                return usersList[0] as User;
            return null;
        }

        public User GetUser(string userID)
        {
            PrepareCommand("select * From tblUsers where colUserID=@UserID");
            command.Parameters.AddWithValue("@UserID", userID);
           
            List<BaseEntity> list = Select();
            UsersList usersList = new UsersList(list);
            if (usersList.Count == 1)
                return usersList[0] as User;
            return null;
        }

    }
}
