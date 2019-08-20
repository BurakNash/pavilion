using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.TagHelpers
{
    [HtmlTargetElement("div",Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
    }
}
