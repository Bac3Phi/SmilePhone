using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
