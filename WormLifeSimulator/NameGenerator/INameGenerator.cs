using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    interface INameGenerator
    {
        public String GenerateName(WorldDto world);
    }
}
