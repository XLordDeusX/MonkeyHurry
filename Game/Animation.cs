using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Animation
    {
        private bool isLoop;
        private string Id;
        private float speed;
        private float currentAnimationTime;
        private int currentFrame = 0;
        private List<Texture> frames = new List<Texture>();

        //Starts from the initial frame
        public Texture CurrentTexture => frames[currentFrame];

        public Animation(string Id,float speed, List<Texture> frames = null, bool isLoop = true)
        {
            this.Id = Id;
            this.speed = speed;
            this.isLoop = isLoop;
            this.frames = frames;
            this.currentFrame = 0;
        }
        public void Reset()
        {
            this.currentFrame = 0;
            this.currentAnimationTime = 0;
        }
        public void Update()
        {
            currentAnimationTime += Program.deltaTime;

            if(currentAnimationTime >= speed)
            {
                currentAnimationTime = 0f;
                currentAnimationTime++;

                if(currentFrame >= frames.Count)
                {
                    if (isLoop)
                    {
                        currentFrame = 0;
                    }
                    else
                    {
                        currentFrame = frames.Count - 1;
                    }
                }
            }
        }
    }
}
