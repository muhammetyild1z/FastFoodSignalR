﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DtoLayer.DiscountDto
{
    public class GetDiscountDto
    {
        public int DiscountID { get; set; }
        public string DiscountTitle { get; set; }
        public int DiscountAmount { get; set; }
        public string DiscountDescription { get; set; }
        public string DiscountImageUrl { get; set; }
    }
}
