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
        private Transform transform;
        private int life;
        private float speedX = 150;
        private float speedY = 150;
        private float posIni;
        private float posFinal;
        private float diffPos;


        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;


        //private float gravity = 10 * Program.deltaTime * Program.deltaTime;

        //private Vector2 gravity = new Vector2(0, 10 * Program.deltaTime * Program.deltaTime);

        private Animation idleLeft;
        private Animation idleRight;
        private Animation runLeft;
        private Animation runRight;
        private Animation jumpLeft;
        private Animation jumpRight;
        private Animation dead;
        private Animation currentAnimation;

        private bool is_grounded = true;

        public Character(Vector2 initialPos)
        {
            transform = new Transform(initialPos, 0, new Vector2(1.5f,1.5f));

            idleLeft = CreateAnimation("Idle", "assets/Animations/Monkey/idle_left_", 2, 0.5f, true);
            idleRight = CreateAnimation("Idle", "assets/Animations/Monkey/idle_right_", 2, 0.5f, true);
            runLeft = CreateAnimation("Run Left", "assets/Animations/Monkey/walking_left_", 3, 0.06f, true);
            runRight = CreateAnimation("Run Right", "assets/Animations/Monkey/walking_right_", 3, 0.06f, true);
            jumpLeft = CreateAnimation("Jump Left", "assets/Animations/Monkey/jumping_left_", 4, 0.1f, false);
            jumpRight = CreateAnimation("Jump Right", "assets/Animations/Monkey/jumping_right_", 4, 0.1f, false);
            dead = CreateAnimation("Dead", "assets/Animations/Monkey/dying_left_", 3, 0.5f, false);
            
            currentAnimation = idleRight;
            //currentAnimation.Reset();
        }

        private Animation CreateAnimation(string p_animationID, string p_path, int p_texturesAmount, float p_animationSpeed, bool p_isLoop)
        {
            List<Texture> animationFrames = new List<Texture>();

            for (int i = 1; i < p_texturesAmount; i++)
            {
                animationFrames.Add(Engine.GetTexture($"{p_path}{i}.png"));
            }

            Animation animation = new Animation(p_animationID, p_animationSpeed, animationFrames, p_isLoop);

            return animation;
        }

        public void Update()
        {
            //currentAnimation = idleRight;
            //Basic movement of the character, without gravity.
            if (diffPos > 0 && is_grounded)
            {
                currentAnimation = idleRight;
            }

            if(diffPos < 0 && is_grounded)
            {
                currentAnimation = idleLeft;
            }

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
                is_grounded = false;
                
                if (diffPos > 0 && is_grounded == false)
                {
                    currentAnimation = jumpRight;
                }
                
                if(diffPos < 0 && is_grounded == false)
                {
                    currentAnimation = jumpLeft;
                }
            }

            //if(!is_grounded)
           
            //Move(gravity);

            currentAnimation.Update();
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, transform.rotation, RealWidth / 2f, RealHeight / 2f);
        }

        public bool IsBoxColliding(Character p_objB)
        {
            float distanceX = Math.Abs(transform.position.x - p_objB.transform.position.x);
            float distanceY = Math.Abs(transform.position.y - p_objB.transform.position.y);

            float sumHalfWidths = RealWidth / 2 + p_objB.RealWidth / 2;
            float sumHalfHeights = RealHeight / 2 + p_objB.RealHeight / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                return true;
            }
            return false;
        }

        public void Move(Vector2 pos)
        {
            posIni = transform.position.x;
            transform.position.x += pos.x * Program.deltaTime;
            posFinal = transform.position.x;
            diffPos = posFinal - posIni;
            transform.position.y += pos.y * Program.deltaTime;
        }
    }
}
