using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    interface IWormLogic
    {
        public (String, bool) GetAction(WorldDto data);
    }
}
