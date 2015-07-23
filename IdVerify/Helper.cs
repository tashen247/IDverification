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

        // This method assumes that the 13-digit id number has 
        // valid digits in position 0 through 12.  
        // Stored in a property 'ParseIdString'.  
        // Returns: the valid digit between 0 and 9, or  
        // -1 if the method fails.
        public int GetControlDigit(string id)
        {
            int d = -1;
            char[] ParsedIdString = id.ToArray();
            
            try
            {
                int a = 0;
                for (int i = 0; i < 6; i++)
                {
                    
                    a += int.Parse(ParsedIdString[2 * i].ToString());
                }
                int b = 0;
                for (int i = 0; i < 6; i++)
                {
                    b = b * 10 + int.Parse(ParsedIdString[2 * i + 1].ToString());
                }
                b *= 2;
                int c = 0;
                do
                {
                    c += b % 10;
                    b = b / 10;
                }
                while (b > 0);
                c += a;
                d = 10 - (c % 10);
                if (d == 10) d = 0;
            }
            catch {/*ignore*/} return d;
        }
    }
}
