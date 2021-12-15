using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WormLifeSimulator.WormLogic
{
    public class OptimalLogic : IWormLogic
    {
        public (string, bool) GetAction(Worm worm, WorldDto data)
        {
            if (data.Foods.Count <= 0)
            {
                return ("Nothing", false);
            }
            Food closestFood = Utils.ClosestFood(worm, data.Foods);
            Worm closestWorm = Utils.ClosestWorm(closestFood, data.Worms);
            if (worm == closestWorm)
            {
                if(worm.Life >= 17)
                {
                    return (Utils.ChooseDirection(closestFood, worm), true);
                }
                return (Utils.ChooseDirection(worm, closestFood), false);
            }
            else
            {
                if (worm.Life >= 13)
                {
                    return (Utils.ChooseDirection(worm, new Field(0, 0)), true);//TODO Учесть столкновение
                }
                else
                {
                    return ("Nothing", false);
                }
            }
        }
    }
}
