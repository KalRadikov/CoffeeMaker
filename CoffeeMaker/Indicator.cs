using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ploeh.Samples.CoffeeMaker
{
    public class Indicator : IObserver<BoilerStatus>
    {
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(BoilerStatus value)
        {
            throw new NotImplementedException();
        }
    }
}
