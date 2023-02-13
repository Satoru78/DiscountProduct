using DiscountProduct.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountProduct.Model
{
    partial class Product
    {
        public string DataColor
        {

            get
            {
                if (DiscountDate.Discount > 0 )
                {
                    var date = DiscountDate.DateEnd - DiscountDate.DateStart;
                    if(date.Days >= 1)
                    {
                        return "Red";
                    }
                    return "Green";
                }
                else
                {
                    return "Red";
                }

            }
        }

    }
}
