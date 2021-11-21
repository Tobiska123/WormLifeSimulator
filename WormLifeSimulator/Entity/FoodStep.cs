﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WormLifeSimulator
{
    class FoodStep
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Step { get; set; }
        public WorldBehevior WorldBehevior { get; set; }
    }
}