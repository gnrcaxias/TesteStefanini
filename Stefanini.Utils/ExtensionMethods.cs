using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Utils
{
    public static class ExtensionMethods
    {
        public static DateTime ToDateTime(this object value)
        {
            var dateTimeReturn = new DateTime();

            if (value == null)
                return dateTimeReturn;

            if (!string.IsNullOrWhiteSpace(value.ToString()) && DateTime.TryParse(value.ToString(), out dateTimeReturn))
                return dateTimeReturn;
            else
                return new DateTime();
        }

        public static int ToInt32(this string value)
        {
            var intReturn = 0;

            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out intReturn))
                return intReturn;
            else
                return 0;
        }


        public static int ToInt32(this object value)
        {
            var intReturn = 0;

            if (value == null)
                return intReturn;

            if (!string.IsNullOrWhiteSpace(value.ToString()) && int.TryParse(value.ToString(), out intReturn))
                return intReturn;
            else
                return 0;
        }

        public static decimal ToDecimal(this string value)
        {
            var decimalReturn = 0m;

            if (!string.IsNullOrWhiteSpace(value) && decimal.TryParse(value, out decimalReturn))
                return decimalReturn;
            else
                return 0;
        }

        public static bool ToBool(this string value)
        {
            var boolReturn = false;

            if (!string.IsNullOrWhiteSpace(value) && bool.TryParse(value, out boolReturn))
                return boolReturn;
            else
                return false;
        }

        public static bool ToBool(this object value)
        {
            var boolReturn = false;

            if (value == null)
                return boolReturn;

            if (!string.IsNullOrWhiteSpace(value.ToString()) && bool.TryParse(value.ToString(), out boolReturn))
                return boolReturn;
            else
                return false;
        }

    }
}
