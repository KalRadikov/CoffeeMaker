using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ploeh.Samples.CoffeeMaker
{
    public class ReliefValve : IObserver<WarmerPlateStatus>
    {
        private readonly ICoffeeMaker hardware;

        public ReliefValve(ICoffeeMaker hardware)
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
            if (value == WarmerPlateStatus.WARMER_EMPTY)
                this.hardware.SetReliefValveState(ReliefValveState.OPEN);
            else
                this.hardware.SetReliefValveState(ReliefValveState.CLOSED);
        }
    }
}
