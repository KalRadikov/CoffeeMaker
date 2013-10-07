﻿using System;
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

        [Theory, TestConventions]
        public void OnCompletedDoesNotThrow(Boiler sut)
        {
            Assert.DoesNotThrow(() => sut.OnCompleted());
        }

        [Theory, TestConventions]
        public void OnErrorDoesNotThrowNotImplementedException(
            Boiler sut,
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
        public void OnNexNotPushedBrewButtonDoesNotThrow(Boiler sut)
        {
            Assert.DoesNotThrow(() => sut.OnNext(BrewButtonStatus.NOT_PUSHED));
        }

        [Theory, TestConventions]
        public void SutIsObserverOfBoilerStatus(Boiler sut)
        {
            Assert.IsAssignableFrom<IObserver<BoilerStatus>>(sut);
        }
    }
}