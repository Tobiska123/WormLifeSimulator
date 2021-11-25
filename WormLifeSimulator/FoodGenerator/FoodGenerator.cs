using System;
using System.Collections.Generic;

namespace WormLifeSimulator
{
    public class FoodGenerator: IFoodGenerator
    {

        private IWorldBeheviorManager worldBeheviorManager;
        private WorldBehevior worldBehevior;
        public FoodGenerator(
            String name,
            IWorldBeheviorManager worldBeheviorManager
        ){
            this.worldBeheviorManager = worldBeheviorManager;
            this.worldBehevior = this.worldBeheviorManager.Create(name); 
        }

        public (int, int) GetFood(WorldDto data)
        {
            while (true)
            {
                int mX = NextNormal();
                int mY = NextNormal();
                if (isFree(mX, mY, data.Worms, data.Foods))
                {
                    this.worldBeheviorManager.StoreStep(
                        this.worldBehevior,
                        new FoodStep()
                        {
                            X = mX,
                            Y = mY,
                            Step = data.Step
                        }
                    );
                    return (mX, mY);
                }
                continue;
            }
        }

        public int NextNormal(double mu = 0, double sigma = 1)
        {
            Random r = new Random();

            var u1 = r.NextDouble();

            var u2 = r.NextDouble();

            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

            var randNormal = mu + sigma * randStdNormal;

            return (int)Math.Round(randNormal);

        }

        public bool isFree(int x, int y, List<Worm> worms, List<Food> foods)
        {
            foreach (Field field in worms)
            {
                if ((field.X == x) && (field.Y == y))
                {
                    return false;
                }
            }

            foreach (Field field in foods)
            {
                if ((field.X == x) && (field.Y == y))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
