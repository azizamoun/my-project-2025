using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;  //must add this 
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class BaseEntity
    {
        [DataMember]
        public int Id { get; set; }
        public BaseEntity() { }
        public BaseEntity(int id)
        {
            Id = id;
        }
    }
}
