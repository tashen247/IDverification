using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdVerify.library
{
    public class Helper
    {
        public Helper()
        {

        }
        public bool ValidDate(string dob)
        {
            bool Success = false;
           DateTime result;
            if (!DateTime.TryParseExact(
                 dob,
                 "yyyyMMdd",
                 CultureInfo.InvariantCulture,
                 DateTimeStyles.AssumeUniversal,
                 out result))
            {
                Success = true;
            };

            return Success;
        }


        
    }
}
