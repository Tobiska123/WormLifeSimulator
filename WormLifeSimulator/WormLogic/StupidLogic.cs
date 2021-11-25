using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    public class StupidLogic : IWormLogic
    {
        public (string, bool) GetAction(Worm worm, WorldDto data)
        {
            Random r = new Random();
            if (r.Next() % 2 == 0)
            {
                return (WorldDto.Up, true);
            }else
            {
                return (WorldDto.Left, false);
            }   
        }
    }
}
