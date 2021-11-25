using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    public interface IWormLogic
    {
        public (String, bool) GetAction(Worm worm, WorldDto data);
    }
}
