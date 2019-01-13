using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DAL;
namespace SmilePhone.Validations
{
    public class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal numberValue;
            return !Decimal.TryParse(value.ToString(), out numberValue) ? new ValidationResult(false, "Không phải là kiểu số") : ValidationResult.ValidResult;
        }
    }
}
