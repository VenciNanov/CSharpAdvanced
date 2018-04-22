// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;

    [TestFixture]
    public class SetControllerTests
    {
        private IStage stage;
        private ISetController setController;
        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
        }

        [Test]
        public void CtorShouldInitilaizeCorrectProperties()
        {
            this.setController = new SetController(stage);
        }

        [Test]
        public void AssertThatSetsAreAddedCorrectly()
        {
            var set1 = new Short("shortSet");
            var set2 = new Medium("mediumSet");
            var set3 = new Long("LongSet");

            this.stage.AddSet(set1);
            this.stage.AddSet(set2);
            this.stage.AddSet(set3);

            Assert.AreEqual(3, this.stage.Sets.Count);
        }

        [Test]
        public void AsserThatSetCanPerform()
        {
            this.
        }
        
    }
}