using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdVerify.library
{
    public class IdVerifyNumber
    {
        private string _id;
        public bool _validDob { get; set; }

        public bool _validGender { get; set; }

        public bool _validCitizen { get; set; }

        public bool _validRace { get; set; }

        public bool _validCheckbit { get; set; }

        public int _checkbit { get; set; }

        Helper _helper = new Helper();

        public string _response { get; set; }

        public IdVerifyNumber(string id)
        {
            _id = id;
        }

        public void Validate()
        {
            try
            {
            _validDob = validDob();
            }
            catch //(Exception Ex)
            {
               // _response = Ex.Message;
                throw new Exception("Not valid date");
            }

            try
            {
            _validGender = ValidGender();
            }
            catch// (Exception Ex)
            {
               // _response = Ex.Message;
                throw new Exception("Not valid Gender");
            }

            try
            {
            _validCitizen = validCitizen();
            }
            catch// (Exception Ex)
            {
               // _response = Ex.Message;
                throw new Exception("Not valid citizen");
            }

            try
            {
            _validRace = validRace();
            }
            catch// (Exception Ex)
            {
               // _response = Ex.Message;
                throw new Exception("Not valid Race");
            }

            try
            {
            _validCheckbit = validCheckbit();
            }
            catch// (Exception Ex)
            {
               // _response = Ex.Message;
                throw new Exception("Not valid checkbit");
            }

            if (_validDob && _validGender && _validCitizen && _validRace)//  && _validCheckbit)
                _response = " ID Number is Valid";
            else
                _response = "Sorry this is not a Valid ID Number  ";


        }


        public bool LengthCheck()
        {
            bool Success = false;

            int count = _id.ToString().Count();

            if (count == 13) Success = true;

            return Success;
        }

        public bool validDob()
        {
            bool Success = false;
            string dob = _id.ToString().Substring(0, 6);

            if (_helper.ValidDate(dob))
            {
                Success = true;
            };

            return Success;
        }

        public bool ValidGender()
        {
            bool Success = false;

            int gender = int.Parse(_id.ToString().Substring(6, 4));

            try
            {
                if (gender >= 5000)
                {
                    Success = true;
                }

                if (gender < 5000)
                {
                    Success = true;
                }
            }
            catch (Exception Ex)
            {
                _response += " " + Ex.Message;
            }

            return Success;
        }

        public bool validCitizen()
        {
            bool Success = false;

            int citizen = int.Parse(_id.ToString().Substring(10, 1));

            try
            {
                if (citizen == 1)
                {
                    Success = true;
                }
                else if (citizen == 0)
                {
                    Success = true;
                }
            }
            catch (Exception Ex)
            {
                _response += " " + Ex.Message;
            }
            return Success;
        }

        public bool validRace()
        {
            bool Success = false;

            int race = int.Parse(_id.ToString().Substring(11, 1));

            if (race == 8)
            {
                Success = true;
            }
            else if (race == 9)
            {
                Success = true;
            }

            return Success;
        }

        public bool validCheckbit()
        {
            bool Success = false;

            try
            {
                _checkbit = _helper.GetControlDigit(_id.ToString());

                if (_checkbit == int.Parse(_id.ToString().Substring(11, 1)))
                    Success = true;
            }
            catch
            {
                throw new Exception("Invalid checkbit");
            }

            return Success;
        }

    }
}
