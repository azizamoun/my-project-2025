using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;  //must add this
namespace Model
{
    [DataContract]
    public class User:BaseEntity
    {
        [DataMember]
        public string Fname { get; set; }
        [DataMember]
        public string Lname {get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public  string Password { get; set; }
        
        [DataMember]
        public string EmailAddress { get; set; }
        
        
        [DataMember]
        public string UserType { get; set; }   //admin , client
        public User() { }
        public User( int UserId,string fname, string lname, string userName, string password, string emailAddress, string userType):base(UserId)
        {
           this.Fname = fname;
            this.Lname = lname;
            this.UserName = userName;
            this.Password = password;
            this.EmailAddress = emailAddress;
            this.UserType = userType;
        }
    }
}
