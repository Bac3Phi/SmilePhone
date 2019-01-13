using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

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

        private static Regex regex;
        public static void FindListViewItem(DependencyObject obj, String searchText ="")
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DataGrid lv = obj as DataGrid;
                if (lv != null)
                {
                    HighlightText(lv, searchText);
                }
                FindListViewItem(VisualTreeHelper.GetChild(obj as DependencyObject, i), searchText);
            }
        }

        private static void HighlightText(Object itx, String searchText)
        {
            if (itx != null)
            {
                if (itx is TextBlock)
                {
                    regex = new Regex("(" + searchText + ")", RegexOptions.IgnoreCase);
                    TextBlock tb = itx as TextBlock;
                    if (searchText.Length == 0)
                    {
                        string str = tb.Text;
                        tb.Inlines.Clear();
                        tb.Inlines.Add(str);
                        return;
                    }
                    string[] substrings = regex.Split(tb.Text);
                    tb.Inlines.Clear();
                    foreach (var item in substrings)
                    {
                        if (regex.Match(item).Success)
                        {
                            Run runx = new Run(item);
                            runx.Background = Brushes.Yellow;
                            tb.Inlines.Add(runx);
                        }
                        else
                        {
                            tb.Inlines.Add(item);
                        }
                    }
                    return;
                }
                else
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(itx as DependencyObject); i++)
                    {
                        HighlightText(VisualTreeHelper.GetChild(itx as DependencyObject, i), searchText);
                    }
                }
            }
        }
    }
}
