using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Model
{
    [CollectionDataContract]
    public class ProductsList:List<Product>
    {
        // A collection for the SELECT result
        public ProductsList() { }
        public ProductsList(IEnumerable<Product> list) : base(list) { }
        public ProductsList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Product>().ToList()) { }

    }

}

