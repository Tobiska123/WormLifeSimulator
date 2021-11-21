using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    class NameGenerator: INameGenerator
    {
        public String GenerateName(WorldDto world)
        {
            while (true)
            {
                String name = this.GetName(6);
                if (this.isNameExists(name, world.Worms))
                {
                    continue;
                }
                return name;
            }

        }
        public string GetName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2;
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }

        private bool isNameExists(String name, List<Worm> worms)
        {
            foreach (Worm worm in worms)
            {
                if (worm.Name.Equals(name))
                {
                    return true;
                }
            }

            return false;
        }
    }
}


