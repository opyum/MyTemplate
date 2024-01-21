using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Resources;
using TemplateX.CrossCutting;

public class PasswordRequirementsAttribute : ValidationAttribute
{

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
            return new ValidationResult(ResourcesText.RequiredPassword);

        var password = value.ToString();

        if (password.Length < 8)
        {
            return new ValidationResult(ResourcesText.PasswordLength);
        }

        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            return new ValidationResult(ResourcesText.PasswordUppercase);
        }

        if (!Regex.IsMatch(password, @"[a-z]"))
        {
            return new ValidationResult(ResourcesText.PasswordLowercase);
        }

        if (!Regex.IsMatch(password, @"[0-9]"))
        {
            return new ValidationResult(ResourcesText.PasswordDigit);
        }

        return ValidationResult.Success;
    }
}
