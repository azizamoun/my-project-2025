using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;  //must add this

namespace Model
{
    [DataContract]
    public class Product:BaseEntity, INotifyPropertyChanged
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Price { get; set; }
        [DataMember]
        public string Quantity { get; set; }
        [DataMember]

        public string Hand { get; set; }
        [DataMember]

        public string Color { get; set; }
        [DataMember]
        public string ImageName { get; set; }
        
        private string imageStr;
        [DataMember]
        public string ImageStr
        {
            get
            {
                return imageStr;
            }
            set
            {
                imageStr = value;
                OnPropertyChanged("ImageStr");
            }
        }
        public Product() { }
        public Product(int ProductID, string Name, string Description,
                       string Price, string Quantity,
                       string ImageStr, string ImageName,string Color,string Hand)
                       : base(ProductID)
        {
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Quantity = Quantity;
            this.ImageStr = ImageStr;
            this.ImageName = ImageName;
            this.Color = Color;
            this.Hand = Hand;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new
                             PropertyChangedEventArgs(propertyName));
        }

    }
}
