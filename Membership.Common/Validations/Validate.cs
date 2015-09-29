using System;
using System.Text.RegularExpressions;

namespace Membership.Common.Validations
{
    public static class Validate
    {
        private const string NUMERIC = @"^\-?[0-9]*\.?[0-9]*$";
        private const string EMAIL = @"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";
        private const string PHONE_US = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

        public static bool IsValidEmail(this string emailToValidate)
        {
            if (String.IsNullOrEmpty(emailToValidate))
                return false;

            Regex re = new Regex(EMAIL);

            return re.IsMatch(emailToValidate);
        }

        public static bool IsValidNumeric(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            Regex re = new Regex(NUMERIC);

            return re.IsMatch(value);
        }

        public static bool IsValidPhoneUS(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            Regex re = new Regex(PHONE_US);

            return re.IsMatch(value);
        }
    }
}