using Coterie_Models;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie_Test
{
    [TestFixture]
    class CalculatedPremiumTests
    {
        [Test]
        [TestCase(6000000, 0.5, 0.943, 1000, 4, 11316)]
        public void Calculation(decimal revenue, decimal businessFactor, decimal stateFactor, decimal baseFactor, decimal hazardFactor, decimal expected)
        {
            var result = new CalculatedPremium(revenue, businessFactor, stateFactor, baseFactor, hazardFactor);

            Assert.AreEqual(expected, result.Premium);
        }
    }
}
