using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie_Models
{
    public class CalculatedPremium
    {
        public decimal Premium { get; set; }

        public CalculatedPremium(decimal revenue, decimal businessFactor, decimal stateFactor, decimal baseFactor, decimal hazardFactor)
        {
            Premium = decimal.Ceiling(revenue / baseFactor) * stateFactor * businessFactor * hazardFactor;
        }
    }
}
