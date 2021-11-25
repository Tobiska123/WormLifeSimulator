using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WormLifeSimulator
{
    public class LoadFood : IFoodGenerator
    {
        private IWorldBeheviorManager worldBeheviorManager;
        private WorldBehevior worldBehevior;
        public LoadFood(
            String name,
            IWorldBeheviorManager worldBeheviorManager
        )
        {
            this.worldBeheviorManager = worldBeheviorManager;
            this.worldBehevior = this.worldBeheviorManager.Load(name);
        }
        public (int, int) GetFood(WorldDto data)
        {
            FoodStep foodStep = this.worldBeheviorManager.Show(this.worldBehevior, data.Step);
            return (foodStep.X, foodStep.Y);
        }
    }
}
