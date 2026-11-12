using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [CollectionDataContract]
    public class UsersList : List<User>
    {
        public UsersList() { } 
        public UsersList(IEnumerable<User> list):base(list) { }
        public UsersList(IEnumerable<BaseEntity>list) :base(list.Cast<User>().ToList()) { }
    }
}
