using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WormLifeSimulator.WormLogic
{
   public class Utils
    {
        public static Food ClosestFood(Worm worm, Food[] foods)
        {
            int min = 100000;
            Food closestFood = foods[0];
            foreach(Food food in foods)
            {
                int distanse = Distance(worm, food);
                if (distanse < min)
                {
                    min = distanse;
                    closestFood = food;
                }
            }
            return closestFood;
        }

        public static Worm ClosestWorm(Food food, Worm[] worms)
        {
            int min = 100000;
            Worm closestWorm = worms[0];
            foreach (Worm worm in worms)
            {
                int distanse = Distance(worm, food);
                if (distanse < min)
                {
                    min = distanse;
                    closestWorm = worm;
                }
            }
            return closestWorm;
        }

        public static int Distance(Field f1, Field f2)
        {
            return Math.Abs(f1.X - f2.X) + Math.Abs(f1.Y - f2.Y);//TODO ввести в растояния коэфициенты по времени жизни (червяк не должен ползти к еде которая скоро протухнет)
        }

        public static String ChooseDirection(Field f1, Field f2)
        {
            if(f1.X != f2.X)
            {
                if (f2.X - f1.X < 0)
                {
                    return "Left";
                }else
                {
                    return "Right";
                }
            }else
            {
                if (f2.Y - f1.Y < 0)
                {
                    return "Down";
                }
                else
                {
                    return "Up";
                }
            }
        }

        public static String OppositeChooseDirection(Field f1, Field f2)
        {
            if (f1.X != f2.X)
            {
                if (f2.X - f1.X < 0)
                {
                    return "Right";
                }
                else
                {
                    return "Left";
                }
            }
            else
            {
                if (f2.Y - f1.Y < 0)
                {
                    return "Up";
                }
                else
                {
                    return "Down";
                }
            }
        }
    }
}
