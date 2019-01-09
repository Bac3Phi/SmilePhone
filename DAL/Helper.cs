using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public static class Helper
    {
        public static String generateAutoID(String tableName, String id, String keyword)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = "";
                var query = "SELECT TOP 1" + id + " FROM " + tableName + " ORDER BY " + id + " DESC";
                var maxID = db.Database
                    .SqlQuery<String>(query)
                    .FirstOrDefault();
                if (maxID == null)
                {
                    result = keyword + "1";
                }
                else
                {
                    var key = Int32.Parse(maxID.Remove(0, keyword.Length));
                    result = keyword + (++key).ToString();
                }
                return result;
            }
        }

        public static bool IsValidEmail(String email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address == email)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPhoneNumber(String number)
        {
            bool result = Regex.Match(number, @"(\+84|0)\d{9,10}$").Success;
            return result;
        }
    }
}
