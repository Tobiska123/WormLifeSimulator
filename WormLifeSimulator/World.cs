using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WormLifeSimulator
{
    public class World
    {
        private List<Worm> worms;
        private List<Food> foods;
        public World()
        {
            this.worms = new List<Worm>();
            this.foods = new List<Food>();
            this.AddWorm(0, 0, "John");

        }

        public void AddWorm(int x, int y, string name)
        {
            if (!this.IsPoinFree(x, y))
            {
                return;
            }

            Worm worm = new Worm(x, y, name);
            this.worms.Add(worm);
        }
        public void AddFood(int x, int y)
        {
            if (!this.IsPoinFree(x, y))
            {
                return;
            }

            Food food = new Food(x, y);
            this.foods.Add(food);
            return;
        }



        public bool IsPoinFree(int x, int y)
        {
            foreach (Field point in this.worms)
            {
                if ((point.X == x) && (point.Y == y))
                {
                    return false;
                }
            }

            foreach (Field point in this.foods)
            {
                if ((point.X == x) && (point.Y == y))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsPoinFreeWorms(int x, int y)
        {
            foreach (Field point in this.worms)
            {
                if ((point.X == x) && (point.Y == y))
                {
                    return false;
                }
            }

            return true;
        }

        public Field GetField(int x, int y)
        {
            foreach (Worm worm in this.worms)//todo linq
            {
                if ((worm.X == x) && (worm.Y == y))
                {
                    return worm;
                }
            }

            foreach (Food food in this.foods)
            {
                if ((food.X == x) && (food.Y == y))
                {
                    return food;
                }
            }

            return new Field(x, y);
        }


        public void ClearWorld()
        {
            this.worms.RemoveAll(w => w.Life <= 0);
            this.foods.RemoveAll(f => f.Life <= 0);
        }

        public void DecreaseFoods()
        {
            foreach (Food food in this.foods)
            {
                food.Life--;
            }
        }

        public List<Worm> Worms
        {
            get { return this.worms.ToList(); }
        }

        public List<Food> Foods
        {
            get { return this.foods; }
        }
    }
}
