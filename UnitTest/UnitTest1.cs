using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Character monkey = new Character("Monkey", new Transform(new Vector2(0, 0), 0, new Vector2(1.5f, 1.5f)));


        [TestMethod]
        public void GetDamageUnitTest()
        {
            int damage = 1;

            var expectLife = monkey.LifePoints - damage;

            monkey.GetDamage(damage);

            var currentLife = monkey.LifePoints;

            Assert.AreEqual(currentLife, expectLife);
        }

        [TestMethod]
        public void GetBananaUnitTest()
        {
            int banana = 1;

            var expectPoints = monkey.BananaGoal + banana;

            monkey.GetBanana(banana);

            var currentPoints = monkey.BananaGoal;

            Assert.AreEqual(currentPoints, expectPoints);
        }

        [TestMethod]
        public void GetPositionPlatformTest()
        {
             int moveY = 10;

            var moveLavaY = monkey.LavaMove + moveY;

            monkey.Move(moveY);

            var moveNormalLava = monkey.LavaMove;

            Assert.AreEqual(moveNormalLava, moveLavaY);

        }

    }
}
