using Microsoft.AspNetCore.Razor.TagHelpers;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.TagHelpers
{
    [HtmlTargetElement("div",Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        public PageInfo PageInfo { get; set; }


    }
}
