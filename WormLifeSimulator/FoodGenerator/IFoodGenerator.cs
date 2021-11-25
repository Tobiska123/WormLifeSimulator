using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    public interface IFoodGenerator
    {
        public (int, int) GetFood(WorldDto data);
    }
}
