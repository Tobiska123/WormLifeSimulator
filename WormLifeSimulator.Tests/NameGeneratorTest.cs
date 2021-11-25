using NUnit.Framework;

namespace WormLifeSimulator.Tests
{
    class NameGeneratorTest
    {
        protected INameGenerator _nameGenerator;
        protected Simulator _simulator;

        [SetUp]
        public void Setup()
        {
            _nameGenerator = new NameGenerator();
            _simulator = new Simulator(
                _nameGenerator,
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
        public void Simulator_Add_New_Worm_With_Unique_Name()
        {
           World world = _simulator.World;
           string name = this._nameGenerator.GenerateName(_simulator.getDto());
            Assert.IsTrue(!world.Worms[0].Name.Equals(name));
        }
    }
}
