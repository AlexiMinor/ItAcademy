using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ItAcademy.MVC.TagHelpers;

public class WatchTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var classes = context.AllAttributes["class"].Value;

        output.TagName = "div";
        output.Attributes.SetAttribute("class", classes);
        output.Content.SetContent(DateTime.Now.ToString("R"));
    }
}