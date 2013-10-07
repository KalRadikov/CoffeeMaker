using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.Samples.CoffeeMaker;
using Xunit;
using Xunit.Extensions;

namespace Ploeh.Samples.CoffeeMaker.UnitTests
{
    public class ReliefValveTests
    {
        [Theory, TestConventions]
        public void SutIsObserverOfWarmerPlateStatus(ReliefValve sut)
        {
            Assert.IsAssignableFrom<IObserver<WarmerPlateStatus>>(sut);
        }
    }
}
