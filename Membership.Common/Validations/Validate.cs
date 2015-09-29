using System;
using System.Text.RegularExpressions;

namespace Membership.Common.Validations
{
    public static class Validate
    {
        private const string NUMERIC = @"^\-?[0-9]*\.?[0-9]*$";
        private const string SOCIAL_SECURITY = @"\d{3}[-]?\d{2}[-]?\d{4}";
        private const string EMAIL = @"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";

        private const string URL = @"^^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_=]*)?$";

        private const string ZIP_CODE_US = @"^\d{5}$";
        private const string ZIP_CODE_US_WITH_FOUR = @"\d{5}[-]\d{4}";
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

        public static bool IsValidSocialSecurity(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            Regex re = new Regex(SOCIAL_SECURITY);

            return re.IsMatch(value);
        }

        public static bool IsValidUrl(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            Regex re = new Regex(URL);

            return re.IsMatch(value);
        }

        public static bool IsValidFiveDigitsUSZipCode(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            Regex re = new Regex(ZIP_CODE_US);

            return re.IsMatch(value);
        }

        public static bool IsValidUSZipCode(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            Regex fiveDigit = new Regex(ZIP_CODE_US);
            Regex fiveDigitPlusFour = new Regex(ZIP_CODE_US_WITH_FOUR);

            return fiveDigit.IsMatch(value) || fiveDigitPlusFour.IsMatch(value);
        }

    }
}