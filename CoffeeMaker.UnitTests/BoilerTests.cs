using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;
using Ploeh.Samples.CoffeeMaker;

namespace Ploeh.Samples.CoffeeMaker.UnitTests
{
    public class BoilerTests
    {
        [Theory, TestConventions]
        public void SutIsObserverOfBrewButtonStatus(Boiler sut)
        {
            Assert.IsAssignableFrom<IObserver<BrewButtonStatus>>(sut);
        }
    }
}
