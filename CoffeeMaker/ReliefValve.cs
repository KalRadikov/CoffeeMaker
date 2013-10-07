using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ploeh.Samples.CoffeeMaker
{
    public class ReliefValve : IObserver<WarmerPlateStatus>
    {
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(WarmerPlateStatus value)
        {
            throw new NotImplementedException();
        }
    }
}
