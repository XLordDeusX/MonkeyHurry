using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum PlatformType
    {
        Small = 0,
        Medium = 1,
        Big = 2
    }

    public static class BananaFactory
    {

        private static GenericPool<Banana> bananasPool = new GenericPool<Banana>();
        public static Banana CreateBanana(Transform p_transform)
        {
            Banana banana = bananasPool.GetObjectsFromPool();

            if (banana == null)
            {
                banana = new Banana("banana", p_transform);
            }
            //else
            //{
            //    banana.transform.position.x = p_transform.position.x;
            //    banana.transform.position.y = p_transform.position.y;
            //}


            bananasPool.AddNewUsedObj(banana);
            banana.OnDie += bananasPool.AddToPool;


            return banana;
        }
    }

    public static class PlatformFactory
    {
        public static Platforms CreatePlatforms(PlatformType platType, Vector2 pos)
        {
            switch (platType)
            {
                case PlatformType.Small:
                    return new Platforms("platform", new Transform(pos, 0, new Vector2(0.5f, 0.5f)));
                case PlatformType.Medium:
                    return new Platforms("platform", new Transform(pos, 0, new Vector2(1f, 1f)));
                case PlatformType.Big:
                    return new Platforms("platform", new Transform(pos, 0, new Vector2(1.5f, 1.5f)));
            }
            return null;
        }
    }
}