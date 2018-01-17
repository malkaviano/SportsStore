using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.TagHelpers
{
    [HtmlTargetElement("nav", Attributes = "page-model")]
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory factory;

        public PageLinkTagHelper(IUrlHelperFactory factory)
        {
            this.factory = factory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext  ViewCtx { get; set; }

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        //[HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        //public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public string PageUlCss { get; set; }

        public string PageActive { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var helper = factory.GetUrlHelper(ViewCtx);
            var ul = new TagBuilder("ul");
            ul.AddCssClass(PageUlCss);

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                var li = new TagBuilder("li");
                var tag = new TagBuilder("a");
                // Não precisou
                //PageUrlValues["page"] = i;
                //tag.Attributes["href"] = helper.Action(PageAction, PageUrlValues);
                tag.Attributes["href"] = helper.Action(PageAction, new { page = i });
                tag.InnerHtml.Append(i.ToString());
                if(i == PageModel.Current) { li.AddCssClass(PageActive); }
                li.InnerHtml.AppendHtml(tag);
                ul.InnerHtml.AppendHtml(li);
            }

            output.Content.SetHtmlContent(ul);
        }
    }
}
