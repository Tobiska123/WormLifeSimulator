using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WormLifeSimulator
{
    interface IWorldBeheviorManager
    {
        public WorldBehevior Create(String name);
        public void StoreStep(WorldBehevior world , FoodStep foodStep);
        public WorldBehevior Load(String name);

        public FoodStep Show(WorldBehevior world, int step);

        public bool Exist(String name);
    }
}
