using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WormLifeSimulator
{
    public class WorldBehevior
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<FoodStep> FoodSteps { get; set; } = new List<FoodStep>();
    }
}
