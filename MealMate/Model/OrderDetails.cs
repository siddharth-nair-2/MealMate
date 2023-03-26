﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MealMate.Model
{
    public class OrderDetails
    {
        public string OrderDetailID { get; set; }
        public string OrderId { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price{ get; set; }
        
    }
}
