using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalBlog.Core.Tools
{
    public static class Utility
    {
        public static Guid CodeGenerator()
        {
            return Guid.NewGuid();
        }

        public static string ConvertToJalali(this DateTime time)
        {
            PersianCalendar pc = new PersianCalendar();
            //1403/12/11
            return pc.GetYear(time).ToString() + "/" +
                   pc.GetMonth(time).ToString("00") + "/" +
                   pc.GetDayOfMonth(time).ToString("00");
        }
    }
}
