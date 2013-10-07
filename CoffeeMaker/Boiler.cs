using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ploeh.Samples.CoffeeMaker
{
    public class Boiler : IObserver<BrewButtonStatus>, IObserver<BoilerStatus>
    {
        private readonly ICoffeeMaker hardware;
        private bool hasWater;

        public Boiler(ICoffeeMaker hardware)
        {
            this.hardware = hardware;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(BrewButtonStatus value)
        {
            if (this.hasWater)
                this.hardware.SetBoilerState(BoilerState.ON);
        }

        public void OnNext(BoilerStatus value)
        {
            this.hasWater = true;
        }
    }
}
