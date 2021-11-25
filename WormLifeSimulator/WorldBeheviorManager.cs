using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WormLifeSimulator
{
    public class WorldBeheviorManager : IWorldBeheviorManager
    {
        private AppContext db;
        public WorldBeheviorManager(
            AppContext db
        ){
            this.db = db;
        }
        public WorldBehevior Create(String name)
        {
            WorldBehevior worldBehevior = new WorldBehevior()
            {
                Name = name
            };
            db.WorldBeheviors.Add(worldBehevior);
            db.SaveChanges();
            return worldBehevior;
        }

        public bool Exist(string name)
        {
           return db.WorldBeheviors.Where(wb => wb.Name == name).Count() == 0 ? false : true;
        }

        public WorldBehevior Load(string name)
        {
            WorldBehevior wb = db.WorldBeheviors.Where(wb => wb.Name == name).First();
            if (wb is null)
            {
                throw new Exception("World Behevior with this name doesn't exist");
            }
            return wb;
        }

        public FoodStep Show(WorldBehevior world, int step)
        {
            return db.FoodSteps.Where(fs => world.Id == fs.WorldBehevior.Id).Where(fs => fs.Step == step).First();
        }

        public void StoreStep(WorldBehevior world, FoodStep foodStep)
        {
            world.FoodSteps.Add(foodStep);
            db.SaveChanges();
        }
    }
}
