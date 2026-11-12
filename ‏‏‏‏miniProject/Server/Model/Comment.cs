using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Comment:BaseEntity
    {
        public string CommentTitle { get; set; }
        public string ComentDetails { get; set; }
        public string IsApproved { get; set; }
        public string CommentDate { get; set; }
        public string UserID { get; set; }   //fk from the userTable, who sent this comment
        public string Author { get; set; }   //Author does not belong to the table and will
                                             //be retrieved by an inner join  with the user's table
        public Comment() { }
        public Comment(int commentID, string commentTitle, string comentDetails, string isApproved, string commentDate, string userID) : base(commentID)
        {
            CommentTitle = commentTitle;
            ComentDetails = comentDetails;
            IsApproved = isApproved;
            CommentDate = commentDate;
            UserID = userID;
        }
           
    }
}
