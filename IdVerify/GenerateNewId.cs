using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdVerify.library
{
    public class GenerateNewId
    {
        public string NewID { get; set; }
        Random rnd = new Random();
        Helper _helper = new Helper();

        public string _date { get; set; }
        public string _gender { get; set; }

        public string _citizen { get; set; }

        public string _race { get; set; }

        public string _checkbit { get; set; }

        public string _result { get; set; }
        public GenerateNewId()
        {
            try
            {

                RandomDOB();
                RandomGender();
                RandomCitizen();
                RandomRacial();
                _helper.GetControlDigit(_date + _gender + _citizen + _race);
                NewID = _date + _gender + _citizen + _race +_checkbit;
            }
            catch 
            {
                _result = "Error Generating new ID";
            }
            
        }

        public string RandomDOB()
        {
            string day ;
            string month;
            int year;

          //  _date = year.ToString().Substring(2, 2) + month.ToString() + day.ToString();

            //bool isValid = false;

            //do
            //{
                 day = rnd.Next(1, 32).ToString();
                 month = rnd.Next(1, 13).ToString();
                 year = rnd.Next(1899, DateTime.Now.Year);

                 if (month.Length == 1) month = "0" + month;
                 if (day.Length == 1) day = "0" + day;       
                _date = year.ToString().Substring(2, 2) + month.ToString() + day.ToString();

                //isValid = _helper.ValidDate(_date);
            //}
            //while (isValid);

            return _date;

        }

        public string Male()
        {
            return rnd.Next(5000, 9000).ToString();
        }

        public string Female()
        {
            return rnd.Next(1000, 5000).ToString();
        }

        public string RandomGender()
        {
            int g = rnd.Next(0, 2);

            if (g == 0)
                _gender = Male();
            else if (g == 1)
                _gender = Female();

            return _gender;
        }

        public string RandomCitizen()
        {
             _citizen = rnd.Next(0, 2).ToString();

            return _citizen;
        }

        public string RandomRacial()
        {
            _race = rnd.Next(8, 10).ToString();

            return _race;
        }

        public string ControlDigit()
        {
            int i = -1;
            string d = _date + _gender + _citizen + _race;
            char[] arr = d.ToArray();
            int y = Convert.ToInt32(arr[0]) + Convert.ToInt32(arr[2]) + Convert.ToInt32(arr[4]) + Convert.ToInt32(arr[6]) + Convert.ToInt32(arr[8]) + Convert.ToInt32(arr[10]);
            int f = Convert.ToInt32((arr[1]+arr[3]+arr[5]+arr[7]+arr[9]+arr[11]) * 2) ;
            char[] g = f.ToString().ToArray();
            int x = Convert.ToInt32((g[0])) + Convert.ToInt32(g[1]) + Convert.ToInt32(g[2]) + Convert.ToInt32(g[3]) + Convert.ToInt32(g[4]);//a + b + c + d + e = x
            int z = x + y ;
            char [] h = x.ToString().ToArray();
            i = 10 - Convert.ToInt32(h[1]);
            _checkbit = i.ToString();
            return _checkbit;
        }


    }
}
