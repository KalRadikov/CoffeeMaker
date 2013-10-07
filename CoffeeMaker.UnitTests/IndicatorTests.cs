﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Extensions;
using Ploeh.Samples.CoffeeMaker;
using Xunit;
using Ploeh.AutoFixture.Xunit;
using Moq;

namespace Ploeh.Samples.CoffeeMaker.UnitTests
{
    public class IndicatorTests
    {
        [Theory, TestConventions]
        public void SutIsObververOfBoilerStatus(Indicator sut)
        {
            Assert.IsAssignableFrom<IObserver<BoilerStatus>>(sut);
        }

        [Theory, TestConventions]
        public void OnCompletedDoesNotThrow(Indicator sut)
        {
            Assert.DoesNotThrow(() => sut.OnCompleted());
        }

        [Theory, TestConventions]
        public void OnErrorDoesNotThrowNotImplementedException(
            Indicator sut,
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
        public void OnNextWarmerEmptyDoesNotThrow(Indicator sut)
        {
            Assert.DoesNotThrow(() => sut.OnNext(BoilerStatus.NOT_EMPTY));
        }

        [Theory, TestConventions]
        public void SutIsObserverOfBrewButtonStatus(Indicator sut)
        {
            Assert.IsAssignableFrom<IObserver<BrewButtonStatus>>(sut);
        }

        [Theory, TestConventions]
        public void OnNextBrewButtonNotPushedDoesNotThrow(Indicator sut)
        {
            Assert.DoesNotThrow(() => sut.OnNext(BrewButtonStatus.NOT_PUSHED));
        }

        [Theory, TestConventions]
        public void StartBrewCycleTurnsOffIndicator(
            [Frozen]Mock<ICoffeeMaker> hardwareMock,
            Indicator sut)
        {
            sut.OnNext(BoilerStatus.NOT_EMPTY);
            sut.OnNext(BrewButtonStatus.PUSHED);

            hardwareMock.Verify(hw => hw.SetIndicatorState(IndicatorState.OFF));
        }
    }
}
