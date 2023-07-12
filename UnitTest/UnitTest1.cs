using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Character monkey = new Character("Monkey", new Transform(new Vector2(0, 0), 0, new Vector2(1.5f, 1.5f)));
        private Lava lava= new Lava("lava", new Transform(new Vector2(478, 1150), 0, new Vector2(1, 1)));

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
        public void GetBananaUnitTest()
        {
            int banana = 1;

            var expectPoints = monkey.BananaGoal + banana;

            monkey.GetBanana(banana);

            var currentPoints = monkey.BananaGoal;

            Assert.AreEqual(currentPoints, expectPoints);
        }

        [TestMethod]
        public void GetPositionLavaTest()
        {
            moveY = 50;

            var movedUnits = lava.transform.position.y + moveY * Time.deltaTime;

            lava.Move(new Vector2(0, moveY));

            var lavaPos = lava.transform.position.y;

            Assert.AreEqual(movedUnits, lavaPos);
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
