using System;
using System.Collections.Generic;

namespace Game
{
	public class Animation
	{
		private bool isLoop;
		private string id;
		private float speed = 0;
		private float currentTime = 0;
		private int currentFrame = 0;
        private List<Texture> frames;

		public Texture CurrentFrame => frames[currentFrame];
		public Animation(string id, float speed, List<Texture> frames, bool isLoop = true)
        {
			this.id = id;
			this.speed = speed;
			this.isLoop = isLoop;
            this.frames = frames;
        }

        public void Reset()
        {
            this.currentFrame = 0;
            this.currentTime = 0;
        }

        public void Update()
        {
            currentTime += Time.deltaTime;

            if (currentTime >= speed)
            {
                currentFrame++;
                currentTime = 0;

                if (currentFrame >= frames.Count)
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

