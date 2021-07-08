using GameClub2.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClub2.Objects
{
    /// <summary>
    /// Checks string and ints. 
    /// String: returns true if it isnt whitespace and longer than threshold
    /// Int: returns true if number is greater than zero
    /// </summary>
    public static class Validator
    {
        private const int stringLenghtThreshold = 4;

        public static bool Validate(string str)
        {
            //str.Trim();
            if (string.IsNullOrWhiteSpace(str) || str.Length < stringLenghtThreshold)
            {
                AlertAboutIncorrect();
                return false;
            }

            return true;
        }
        public static bool Validate(string str, string oldValue)
        {
            //str.Trim();
            if (str == oldValue)
                return false;
            if (string.IsNullOrWhiteSpace(str) | str.Length < stringLenghtThreshold)
            {
                AlertAboutIncorrect();
                return false;
            }

            return true;
        }
        public static bool Validate(int num)
        {

            if (num <= 0)
            {
                AlertAboutIncorrect();
                return false;
            }

            return true;
        }
        public static bool Validate(int num, int oldValue)
        {
            if (num == oldValue)
                return false;
            if (num <= 0)
            {
                AlertAboutIncorrect();
                return false;
            }
            return true;
        }
        public static bool ValidateRange(object[] values)
        {
            Console.Error.WriteLine("Started array validation");
            if (values.Length <= 0)
                return false;
            foreach(object val in values)
            {
                if (val is int)
                {
                    Console.Error.WriteLine("This value was int. Validating");

                    if (!Validate(Convert.ToInt32(val)))
                        return false;
                }
                else if(val is string)
                {
                    Console.Error.WriteLine("This value was string. Validating");

                    if (!Validate(val.ToString()))
                        return false;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        static private void AlertAboutIncorrect()
        {
            MessageBox.Show("Текстові дані повинні бути довше чотирьох символів і не бути повнісью пробільним. Числові дані мають бути додатніми", "Неправильний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
