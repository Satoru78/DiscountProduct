using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountProduct.Model;

namespace ApiServer.Model
{
    class ResponseProduct
    {
        public ResponseProduct(Product product)
        {
            this.ID = product.ID;
            this.Title = product.Title;
            this.IDUnit = product.IDUnit;
            this.Count = product.Count;
            this.IDDiscount = product.IDDiscount;
            this.Manufacturer = product.Manufacturer;
            this.Supplier = product.Supplier;
            this.IDProductCategory = product.IDProductCategory;
            this.QuantitiInStock = product.QuantitiInStock;
            this.Description = product.Description;

        }
        public ResponseProduct() { }
        public int ID { get; set; }
        public string Title { get; set; }
        public int IDUnit { get; set; }
        public decimal Count { get; set; }
        public int IDDiscount { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        public int IDProductCategory { get; set; }
        public int QuantitiInStock { get; set; }
        public string Description { get; set; }
    }
}
