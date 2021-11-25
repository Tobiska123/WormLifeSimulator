using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    public interface ILogger
    {
        public void Log(WorldDto data);
    }
}
