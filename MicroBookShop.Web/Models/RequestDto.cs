﻿using MicroBookShop.Web.Utility;

namespace MicroBookShop.Web.Models
{
    public class RequestDto
    {
        public SD.ApiType ApiType { get; set; } = SD.ApiType.GET;
        
        public string Url { get; set; }
        
        public object Data { get; set; }

        public string AccessToken { get; set; }
    }
}
