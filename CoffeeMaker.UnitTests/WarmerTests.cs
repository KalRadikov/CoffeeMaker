using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;
using Ploeh.Samples.CoffeeMaker;
using Ploeh.AutoFixture.Xunit;
using Moq;

namespace Ploeh.Samples.CoffeeMaker.UnitTests
{
    public class WarmerTests
    {
        [Theory, TestConventions]
        public void SutIsObserverOfWarmerPlateStatus(Warmer sut)
        {
            Assert.IsAssignableFrom<IObserver<WarmerPlateStatus>>(sut);
        }

        [Theory, TestConventions]
        public void OnCompletedDoesNotThrow(Warmer sut)
        {
            Assert.DoesNotThrow(() => sut.OnCompleted());
        }

        [Theory, TestConventions]
        public void OnErrorDoesNotThrowNotImplementedException(
            Warmer sut,
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
        public void OnNextWarmerEmptyDoesNotThrow(Warmer sut)
        {
            Assert.DoesNotThrow(() => sut.OnNext(WarmerPlateStatus.WARMER_EMPTY));
        }

        [Theory, TestConventions]
        public void OnNexPotNotEmptyTurnsOnWarmer(
            [Frozen]Mock<ICoffeeMaker> hardwareMock,
            Warmer sut)
        {
            sut.OnNext(WarmerPlateStatus.POT_NOT_EMPTY);

            hardwareMock.Verify(hw => hw.SetWarmerState(WarmerState.ON));
            hardwareMock.Verify(
                hw => hw.SetWarmerState(WarmerState.OFF),
                Times.Never());
        }

        [Theory, TestConventions]
        public void OnNextPotEmptyTurnsOffWarmer(
            [Frozen]Mock<ICoffeeMaker> hardwareMock,
            Warmer sut)
        {
            sut.OnNext(WarmerPlateStatus.POT_EMPTY);

            hardwareMock.Verify(hw => hw.SetWarmerState(WarmerState.OFF));
            hardwareMock.Verify(
                hw => hw.SetWarmerState(WarmerState.ON),
                Times.Never());
        }

        [Theory, TestConventions]
        public void OnNextWarmerEmptyTurnsOffWarmer(
            [Frozen]Mock<ICoffeeMaker> hardwareMock,
            Warmer sut)
        {
            sut.OnNext(WarmerPlateStatus.WARMER_EMPTY);

            hardwareMock.Verify(hw => hw.SetWarmerState(WarmerState.OFF));
            hardwareMock.Verify(
                hw => hw.SetWarmerState(WarmerState.ON),
                Times.Never());
        }
    }
}
