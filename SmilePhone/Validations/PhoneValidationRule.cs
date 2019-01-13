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
    public class PhoneValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return !Helper.IsPhoneNumber(value.ToString()) ? new ValidationResult(false, "Không phải là kiểu số điện thoại") : ValidationResult.ValidResult;
        }
    }
}
