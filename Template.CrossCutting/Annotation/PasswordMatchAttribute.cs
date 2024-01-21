using TemplateX.CrossCutting;
using System.ComponentModel.DataAnnotations;
using Template.CrossCutting;

public class PasswordsMatchAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public PasswordsMatchAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        
        var currentValue = value as string;

        var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
        if (property == null)
            throw new ArgumentException("Property with this name not found");

        var comparisonValue = property.GetValue(validationContext.ObjectInstance) as string;

        if (currentValue == comparisonValue)
            return ValidationResult.Success;

        return new ValidationResult(ResourcesText.login_error_password_mismatch);
    }
}