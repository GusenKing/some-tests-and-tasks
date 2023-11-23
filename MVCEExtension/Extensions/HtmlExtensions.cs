using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCEExtension.Models;

namespace MVCEExtension.Extensions;

public static class HtmlExtensions
{
    public static IHtmlContent Ca lculateAndShowResult(this IHtmlHelper helper)
    {
        var model = helper.ViewData.Model;
        if (model == null)
            return new HtmlString("");
        
        var properties = helper.ViewData.ModelMetadata.ModelType.GetProperties();
        var firstNumber = properties[0].GetValue(model) as double?;
        var operation = properties[1].GetValue(model) as string;
        var secondNumber = properties[2].GetValue(model) as double?;
        double? result;
        Console.WriteLine(operation);
        switch (operation)
        {
            case "+":
                result = firstNumber + secondNumber;
                break;
            case "-":
                result = firstNumber - secondNumber;
                break;
            case "*":
                result = firstNumber * secondNumber;
                break;
            case "/":
                result = firstNumber / secondNumber;
                break;
            default:
                result = null;
                break;
        }
        return new HtmlString($"<span style=\"font-size: 20\">{result}</span>");
    }
}