using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    interface ILogger
    {
        public void Log(WorldDto data);
    }
}
