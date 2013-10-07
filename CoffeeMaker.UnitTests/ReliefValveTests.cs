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

        [Theory, TestConventions]
        public void OnCompletedDoesNotThrow(ReliefValve sut)
        {
            Assert.DoesNotThrow(() => sut.OnCompleted());
        }

        [Theory, TestConventions]
        public void OnErrorDoesNotThrowNotImplementedException(
            ReliefValve sut,
            Exception e)
        {
            try
            {
                sut.OnError(e);
            }
            catch (NotImplementedException)
            {
                Assert.True(false, "NotImplementedException thrown.");
            }
        }

        [Theory, TestConventions]
        public void OnNextWarmerEmptyDoesNotThrow(ReliefValve sut)
        {
            Assert.DoesNotThrow(() => sut.OnNext(WarmerPlateStatus.WARMER_EMPTY));
        }
    }
}
