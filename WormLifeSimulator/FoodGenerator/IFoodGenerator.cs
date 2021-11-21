using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    interface IFoodGenerator
    {
        public (int, int) GetFood(WorldDto data);
    }
}
