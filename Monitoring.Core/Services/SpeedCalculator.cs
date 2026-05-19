using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monitoring.Core.Models;

namespace Monitoring.Core.Services
{
    
    public class SpeedCalculator
    {
        public double Calculate (PositionSample oldPos, PositionSample newPos)
        {
            var deltaValue = newPos.Value - oldPos.Value;
            var deltaTime = (newPos.Timestamp - oldPos.Timestamp).TotalSeconds;

            if (deltaTime == 0) return 0;

            return deltaValue / deltaTime;
        }
    }
}