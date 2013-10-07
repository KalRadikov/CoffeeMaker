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
        private bool isBrewing;

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
            this.hasWater = value == BoilerStatus.NOT_EMPTY;
            if (this.isBrewing && value == BoilerStatus.EMPTY)
                this.hardware.SetIndicatorState(IndicatorState.ON);
        }

        public void OnNext(BrewButtonStatus value)
        {
            if (this.hasWater && value == BrewButtonStatus.PUSHED)
            {
                this.hardware.SetIndicatorState(IndicatorState.OFF);
                this.isBrewing = true;
            }
        }
    }
}
