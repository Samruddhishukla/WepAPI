using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodProject.API.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public string Ordername { get; set; }
        public int Orderquantity { get; set; }
        public int Orderprice { get; set; }
        public string DeliveryAddress { get; set; }
        public string Paymentmethod { get; set; }

    }
}