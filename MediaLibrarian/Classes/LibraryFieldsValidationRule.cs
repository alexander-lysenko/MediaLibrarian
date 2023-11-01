using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace MediaLibrarian.Classes
{
    internal class LibraryFieldsValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var fieldName = (string)value;

            if (string.IsNullOrEmpty(fieldName))
            {
                return new ValidationResult(
                    false,
                    Application.Current.Resources["LibManager.FieldIsBlank"]
                );
            }

            return ValidationResult.ValidResult;
        }
    }
}