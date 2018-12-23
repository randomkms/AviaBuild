using System.Globalization;
using System.Windows.Controls;

namespace AviaBuild.Helpers
{
    public class StrValidator : ValidationRule
    {
        public StrValidator()
        {
            this.ValidatesOnTargetUpdated = true;
        }

        public bool NotNeedValue { get; set; }
        public int Length { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;

            if (string.IsNullOrWhiteSpace(str))
            {
                if (NotNeedValue)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "* Поле не заполнено.");
            }

            if (Length != 0 && str.Length != Length)
                return new ValidationResult(false, "* Поле должно содержать " + Length + " символов.");

            return ValidationResult.ValidResult;
        }
    }
}