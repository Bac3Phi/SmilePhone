using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SmilePhone.Validations
{
    public class MaxLengthValidationRule : ValidationRule
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int intValue = value.ToString().Length ;
            string text = String.Format("Độ dài phải từ {0} đến {1}",
                           MinValue, MaxValue);
            if (intValue < MinValue)
                return new ValidationResult(false, "quá nhỏ. " + text);
            if (intValue > MaxValue)
                return new ValidationResult(false, "quá lớn. " + text);
            return ValidationResult.ValidResult;
        }
    }
}
