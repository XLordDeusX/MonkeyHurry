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