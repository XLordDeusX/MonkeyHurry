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
        private float speedX = 150;
        private float speedY = 150;


        //private float gravity = 10 * Program.deltaTime * Program.deltaTime;

        //private Vector2 gravity = new Vector2(0, 10 * Program.deltaTime * Program.deltaTime);

        private Animation idle;
        private Animation runLeft;
        private Animation runRight;
        private Animation jumpLeft;
        private Animation jumpRight;
        private Animation dead;
        private Animation currentAnimation;

        //private bool is_grounded = true;

        public Character(Vector2 initialPos)
        {
            transform = new Transform(initialPos, 0, new Vector2(1.5f,1.5f));

            idle = CreateAnimation("Idle", "assets/Animations/Monkey/idle_", 3, 0.5f);
            runLeft = CreateAnimation("Run Left", "assets/Animations/Monkey/walking_left_", 3, 0.06f);
            runRight = CreateAnimation("Run Right", "assets/Animations/Monkey/walking_right_", 3, 0.06f);
            jumpLeft = CreateAnimation("Jump Left", "assets/Animations/Monkey/jumping_left_", 4, 0.5f);
            jumpRight = CreateAnimation("Jump Right", "assets/Animations/Monkey/jumping_right_", 4, 0.5f);
            dead = CreateAnimation("Dead", "assets/Animations/Monkey/dying_left_", 3, 0.5f);
            
            currentAnimation = idle;
            //currentAnimation.Reset();
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

            currentAnimation = idle;
            //Basic movement of the character, without gravity.
            if (Engine.GetKey(Keys.D))
            {
                Move(new Vector2(speedX, 0));
                currentAnimation = runRight;
            }
           
            if (Engine.GetKey(Keys.A))
            {
                Move(new Vector2(-speedX, 0));
                currentAnimation = runLeft;
            }
           
            if (Engine.GetKey(Keys.W))
            {
                Move(new Vector2(0, -speedY));
                currentAnimation = jumpLeft;
            }

            //if(!is_grounded)
           
            //Move(gravity);

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
