using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute; 

namespace Oware.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestResetHouse()
        {
            // ARRANGE:
            House h = new House(0, 0);//create a house
            for (int i = 0; i < 4; i++) {
                h.AddSeedInPot(new Seed()); 
            } //modify the house from its intial state
            // ACT:
            h.ResetHouse(); //call the method for testing
            // ASSERT:
            Assert.AreEqual(4, h.GetCount(), "Reset houses must have 4 seeds in them.");//should be returned to original state
        }

        [Test]
        public void TestingAddSeeds()
        {
            //ARRANGE 
            IScoreHouse sh = new ScoreHouse();
            IScoreHouse mock = Substitute.For <IScoreHouse>();  
            Seed s = new Seed();
            mock.AddSeed(s);
            mock.GetCount().Returns(1);
            sh = mock;
            Player p = new Player ("Mock Player", sh); 
            //ACT 
            p.AddSeedToScoreHouse(s); 
            //ASSERT
            Assert.AreEqual(1, sh.GetCount(), "There should be one more seed in ScoreHouse");
            sh.Received().AddSeed(s);
            sh.Received().GetCount();
        }
    }
}