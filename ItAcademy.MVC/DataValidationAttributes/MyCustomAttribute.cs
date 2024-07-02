using System.ComponentModel.DataAnnotations;

namespace ItAcademy.MVC.DataValidationAttributes;

public class MyCustomAttribute : ValidationAttribute
{
    private readonly double _maxValue;

    public MyCustomAttribute(double maxValue)
    {
        _maxValue = maxValue;
    }
    public override bool IsValid(object? value)
    {

        return value != null 
               && double.TryParse(value.ToString(), out var dValue) 
               && dValue <= _maxValue;
    }
}