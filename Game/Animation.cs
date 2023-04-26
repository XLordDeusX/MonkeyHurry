using System;
using System.Collections.Generic;

namespace Game
{
	public class Animation
	{
		private bool isLoop;
		private string id;
		private float speed;
		private float currentTime;
		private int currentFrame = 0;
		private List<Texture> frames = new List<Texture>();

		public Texture CurrentTexture => frames[currentFrame];
		public Animation(string id, float speed, List<Texture> textures = null, bool isLoop = true)
        {
			this.id = id;
			this.speed = speed;
			this.isLoop = isLoop;
			this.currentFrame = 0;

			if(textures == null)
            {
				this.frames = textures;
            }
        }

		public void Update()
        {
            currentTime += Program.deltaTime;

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

