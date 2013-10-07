using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ploeh.Samples.CoffeeMaker
{
    public class Indicator : IObserver<BoilerStatus>, IObserver<BrewButtonStatus>
    {
        private readonly ICoffeeMaker hardware;
        private bool hasWater;

        public Indicator(ICoffeeMaker hardware)
        {
            this.hardware = hardware;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(BoilerStatus value)
        {
            this.hasWater = true;
        }

        public void OnNext(BrewButtonStatus value)
        {
            if (this.hasWater)
                this.hardware.SetIndicatorState(IndicatorState.OFF);
        }
    }
}
