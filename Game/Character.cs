using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //This part is related to the main character
    public class Character
    {
        //private string image;
        private Transform transform;
        private float speedX = 100;
        private float speedY = 100;

        private Animation idle;
        private Animation run;
        private Animation jump;
        private Animation dead;
        private Animation currentAnimation;

        public Character(Vector2 initialPos)
        {
            transform = new Transform(initialPos, 0, new Vector2(1,1));

            idle = CreateAnimation("Idle", "assets/Animations/Monkey/walking_", 3, 0.5f);
            currentAnimation = idle;
            currentAnimation.Reset();
        }

        private Animation CreateAnimation(string p_animationID, string p_path, int p_texturesAmount, float p_animationSpeed)
        {
            List<Texture> animationFrames = new List<Texture>();

            for (int i = 1; i < p_texturesAmount; i++)
            {
                animationFrames.Add(Engine.GetTexture($"{p_path}{i}.png"));
            }

            Animation animation = new Animation(p_animationID, p_animationSpeed, animationFrames, true);

            return animation;
        }

        public void Update()
        {
            //Basic movement of the character, without gravity.
            if (Engine.GetKey(Keys.D))
            {
                Move(new Vector2(speedX, 0));
            }
            if (Engine.GetKey(Keys.S))
            {
                Move(new Vector2(0, speedY));
            }
            if (Engine.GetKey(Keys.A))
            {
                Move(new Vector2(-speedX, 0));
            }
            if (Engine.GetKey(Keys.W))
            {
                Move(new Vector2(0, -speedY));
            } 

            currentAnimation.Update();
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, transform.rotation);
        }

        public void Move(Vector2 pos)
        {
            transform.position.x += pos.x * Program.deltaTime;
            transform.position.y += pos.y * Program.deltaTime;
        }
    }
}
