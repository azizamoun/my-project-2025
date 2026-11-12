using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UsefulLinksList:List<UsefulLink>
    {
        public UsefulLinksList() { }
        public UsefulLinksList(IEnumerable<UsefulLink> list):base(list) { }
        public UsefulLinksList(IEnumerable<BaseEntity> list):base(list.Cast<UsefulLink>().ToList()) { }
    }
}
