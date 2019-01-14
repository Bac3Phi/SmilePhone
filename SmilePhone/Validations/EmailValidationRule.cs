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
    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return !Helper.IsValidEmail(value.ToString()) ? new ValidationResult(false, "Không phải là kiểu email") : ValidationResult.ValidResult;
        }
    }
}
