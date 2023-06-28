using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Character monkeyLife = new Character("Monkey", new Transform(new Vector2(0, 0), 0, new Vector2(1.5f, 1.5f)));


        [TestMethod]
        public void GetDamgeUnitTest()
        {
            int damage = 1;

            var expectLife = monkeyLife.LifePoints - damage;

            monkeyLife.GetDamage(damage);

            var currentLife = monkeyLife.LifePoints;

            Assert.AreEqual(currentLife, expectLife);
        }
    }
}
