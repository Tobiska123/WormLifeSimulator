using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WormLifeSimulator
{
    class Simulator :IHostedService
    {
        World world;//некоторый сериализуемый формат данных
        INameGenerator nameGenerator;
        ILogger logger;
        IFoodGenerator foodGenerator;
        IWormLogic logic;
        List<FoodStep> foodSteps;

        int step;

        public Simulator(
            INameGenerator nameGenerator,
            ILogger logger,
            IFoodGenerator foodGenerator,
            IWormLogic logic
        ){
            this.nameGenerator = nameGenerator;
            this.logger = logger;
            this.foodGenerator = foodGenerator;
            this.logic = logic;
            this.foodSteps = new List<FoodStep>();
            this.world = new World();
        }


        private WorldDto getDto()
        {
            return new WorldDto()
            {
                Worms = this.world.Worms,
                Foods = this.world.Foods,
                Step = this.step
            };
        }

        private void makeFood()
        {
            var (x, y) = this.foodGenerator.GetFood(this.getDto());
            this.world.AddFood(x, y);
            this.foodSteps.Add(new FoodStep() {
                X = x,
                Y = y,
                Step = this.step
            });
        }

        public void StartSimulation()
        {
            for (this.step = 0; this.step < 100; this.step++)
            {
                this.makeFood();
                this.DoStep();
                this.world.DecreaseFoods();
                this.world.ClearWorld();
            }

        }


        public (int, int) MbDirection(Worm worm, String direction)
        {
            if (direction.Equals(WorldDto.Up))
            {
                return (worm.X, worm.Y + 1);
            }
            else if(direction.Equals(WorldDto.Down))
            {
                return (worm.X, worm.Y - 1);
            }
            else if (direction.Equals(WorldDto.Left))
            {
                return (worm.X - 1, worm.Y);
            }
            else if (direction.Equals(WorldDto.Right))
            {
                return (worm.X + 1, worm.Y);
            }
            else
            {
                return (worm.X, worm.Y);
            }
        }


        public void DoStep()
        {
            foreach (Worm worm in this.world.Worms)//Вопрос ToList копирует только списки или обьекты внутри него тоже?
            {
                var (direction, split) = this.logic.GetAction(this.getDto());
                var (mX, mY) = this.MbDirection(worm, direction);

                var field = this.world.GetField(mX, mY);

                if (!(field is Worm))
                {

                    if (split == true)
                    {
                        this.world.AddWorm(
                            mX,
                            mY,
                            this.nameGenerator.GenerateName(this.getDto())
                        );
                        worm.Life -= 10;
                    }
                    else
                    {
                        worm.X = mX;
                        worm.Y = mY;
                    }
                }

                if (field is Food)
                {
                    worm.Life += 10;
                    this.world.Foods.Remove((Food)field);
                }

                worm.DecreaseLife();
            }
            try
            {
                this.logger.Log(this.getDto());
            }
            catch (Exception ex)
            {

            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.StartSimulation();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
