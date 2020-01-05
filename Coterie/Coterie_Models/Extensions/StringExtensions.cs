using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie_Models.Extensions
{
    public static class StringExtensions
    {
        public static decimal ToDecimal(this string input, decimal defaultValue = 0)
        {
            decimal result = defaultValue;

            return decimal.TryParse(input, out result) ? result : defaultValue;
        }
    }
}
