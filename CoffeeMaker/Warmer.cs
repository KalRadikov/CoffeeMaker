using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ploeh.Samples.CoffeeMaker
{
    public class Warmer : IObserver<WarmerPlateStatus>
    {
        private readonly ICoffeeMaker hardware;

        public Warmer(ICoffeeMaker hardware)
        {
            this.hardware = hardware;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(WarmerPlateStatus value)
        {
            if (value == WarmerPlateStatus.POT_NOT_EMPTY)
                this.hardware.SetWarmerState(WarmerState.ON);
            else
                this.hardware.SetWarmerState(WarmerState.OFF);
        }
    }
}
