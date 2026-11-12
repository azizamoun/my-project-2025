using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UsefulLink : BaseEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Date { get; set; }

        public UsefulLink() { }
        public UsefulLink(int ID, string title, string url, string date) : base(ID)
        {
            Title = title;
            Url = url;
            Date = date;
        }

        public UsefulLink(int ID) : base(ID) { }
    }
}
