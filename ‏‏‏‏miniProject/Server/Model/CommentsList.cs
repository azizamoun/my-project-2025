
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommentsList:List<Comment>
    {
        public CommentsList() { }
        public CommentsList(IEnumerable<Comment> list):base(list) { }
        public CommentsList(IEnumerable<BaseEntity> list) :base(list.Cast<Comment>().ToList()) { }

    }
}
