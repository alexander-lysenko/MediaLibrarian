using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace MediaLibrarian.Classes
{
    // https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-binding-validation
    internal class LibraryTitleValidationRule : ValidationRule
    {
        // ReSharper disable once ConvertIfStatementToReturnStatement
        // ReSharper disable once InvertIf
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var msgTitleIsBlank = Application.Current.Resources["LibManager.TitleIsBlank"];
            var msgTitleIsTaken = Application.Current.Resources["LibManager.TitleIsTaken"];
            
            var title = (string)value;

            if (string.IsNullOrEmpty(title))
            {
                return new ValidationResult(false, msgTitleIsBlank);
            }

            var libsList = new List<string> { "Title", "Admin", "kek" };
            var isTitleTaken = false;

            libsList.ForEach(lib =>
            {
                if (string.Equals(title.ToLowerInvariant(), lib.ToLowerInvariant()))
                    isTitleTaken = true;
            });

            if (isTitleTaken)
            {
                return new ValidationResult(false, msgTitleIsTaken);
            }

            return ValidationResult.ValidResult;
        }
    }
}