using Microsoft.AspNetCore.Razor.TagHelpers;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.WebUI.TagHelpers
{
    [HtmlTargetElement("div",Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        public PageInfo PageInfo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul class='pagination'>");

            for (int i = 1; i < PageInfo.TotalPages(); i++)
            {
                stringBuilder.AppendFormat("<li class='page-item{0}'>", i == PageInfo.CurrentPage ? "active" : "");
                
                if (string.IsNullOrEmpty(PageInfo.CurrentCategory))
                {
                    stringBuilder.AppendFormat("<a class='page-link' href='/products?page={0}'>{0}</a>", i);
                }
                else
                {
                    stringBuilder.AppendFormat("<a class='page-link' href='/products/{1}?page={0}'>{0}</a>", i, PageInfo.CurrentCategory);
                    //If the currenty category is not null or empty, stringbuilder will locate to product/ subfolder
                }
            }

            base.Process(context, output);
        }
    }
}
