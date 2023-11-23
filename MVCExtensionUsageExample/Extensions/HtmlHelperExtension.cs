using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCExtensionUsageExample.Models;
using MVCExtensionUsageExample.Views.MyTemp;

namespace MVCExtensionUsageExample.Extensions;

public static class HtmlHelperExtension
{
    public static IHtmlContent MakeSomeContent(this IHtmlHelper htmlHelper, int a)
    {
        return htmlHelper.Partial(nameof(PartialView), new PartialViewModel()
        {
            A = a
        });
    }
}