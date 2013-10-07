using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Extensions;
using Ploeh.Samples.CoffeeMaker;
using Xunit;

namespace Ploeh.Samples.CoffeeMaker.UnitTests
{
    public class IndicatorTests
    {
        [Theory, TestConventions]
        public void SutIsObververOfBoilerStatus(Indicator sut)
        {
            Assert.IsAssignableFrom<IObserver<BoilerStatus>>(sut);
        }
    }
}
