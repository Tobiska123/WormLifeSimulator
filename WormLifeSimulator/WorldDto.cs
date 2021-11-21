using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    class WorldDto
    {
        public const string Up = "Up";
        public const string Down = "Down";
        public const string Left = "Left";
        public const string Right = "Right";

        public List<Worm> Worms { get; set; }
        public List<Food> Foods { get; set; }
        public int Step { get; set; }
    }
}
