using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ItAcademy.MVC.TagHelpers;

[HtmlTargetElement(Attributes = "header")]
public class H1TagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "h1";
        output.Attributes.RemoveAll("header");
    }
}