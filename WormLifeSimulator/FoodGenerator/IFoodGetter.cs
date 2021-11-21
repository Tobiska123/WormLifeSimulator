using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WormLifeSimulator
{
    interface IFoodGetter
    {
        public (int, int) Food(WorldDto worldDto);
    }
}
