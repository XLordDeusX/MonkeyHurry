using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Character monkey = new Character("monkey", new Transform(new Vector2(0, 0), 0, new Vector2(1.5f, 1.5f)));
        private Lava lava = new Lava("lava", new Transform(new Vector2(478, 1150), 0, new Vector2(1, 1)));

        public int moveY;

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
        public void GetStarUnitTest()
        {
            int star = 1;

            var expectPoints = monkey.StarGoal + star;

            monkey.GetStar(star);

            var currentPoints = monkey.StarGoal;

            Assert.AreEqual(currentPoints, expectPoints);
        }


        [TestMethod]

        public void GetDestroyUnitTest()
        {
            monkey.IsDestroyed = false;

            float timer = 2f;


            if (Engine.GetKey(Keys.J))
            {
                monkey.IsDestroyed = true;
            }

            Assert.IsTrue(monkey.IsDestroyed = true);
        }
    }
}
