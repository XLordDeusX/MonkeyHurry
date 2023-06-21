using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Time
    {
        public static float deltaTime;
        public static DateTime startTime;
        public static float lastFrameTime;

        public void InitializedTime()
        {
            startTime = DateTime.Now;
        }

        public void Update()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
        }
    }
}
