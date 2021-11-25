using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    public interface INameGenerator
    {
        public String GenerateName(WorldDto world);
    }
}
