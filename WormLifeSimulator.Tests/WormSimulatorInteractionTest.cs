using WormLifeSimulator;
using NUnit.Framework;

namespace WormLifeSimulator
{
    class WormSimulatorInteractionTest
    {
        protected Simulator _simulator;
        [SetUp]
        public void Setup()
        {
            _simulator = new Simulator(
                new NameGenerator(),
                new OutputFileWriter(),
                new FoodGenerator(
                    "name",
                    new WorldBeheviorManager(
                        new AppContext()
                    )
                ),
                new StupidLogic()
            );
        }

        [Test]
        public void One_Worm_Move_To_Empty_Field()
        {
           Worm worm = _simulator.World.Worms[0];
            _simulator.Move(worm, 2, 2, false);
            Assert.IsTrue((worm.X == 2) && (worm.Y == 2) && (worm.Life == 9));
        }

        [Test]
        public void One_Worm_Move_To_Food_Field()
        {
            _simulator.World.AddFood(5, 5);
            Worm worm = _simulator.World.Worms[0];
            _simulator.Move(worm, 5, 5, false);
            Assert.IsTrue((worm.X == 5) && (worm.Y == 5) && (worm.Life == 19));
        }

        [Test]
        public void One_Worm_Move_To_Worm_Field()
        {
            _simulator.World.AddWorm(10, 10, "h");
            Worm worm = _simulator.World.Worms[0];
            _simulator.Move(worm, 10, 10, false);
            Assert.IsTrue((worm.X != 10) && (worm.Y != 10) && (worm.Life == 9));
        }

        [Test]
        public void One_Worm_Bud_To_Empty_Field()
        {
            Worm worm = _simulator.World.Worms[0];
            _simulator.Move(worm, 1, 1, true);
            Assert.IsTrue((_simulator.World.Worms.Count == 2) && (_simulator.World.Worms[0].Life == 0) && (_simulator.World.Worms[1].Life == 10));
        }

        [Test]
        public void One_Worm_Bud_To_Worm_Field()
        {
            _simulator.World.AddWorm(2, 2, "h");
            Worm worm = _simulator.World.Worms[0];
            _simulator.Move(worm, 2, 2, true);
            Assert.IsTrue(_simulator.World.Worms.Count == 1);
        }
    }
}
