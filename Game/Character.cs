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
        private Animation idleLeft;
        private Animation idleRight;
        private Animation runLeft;
        private Animation runRight;
        private Animation jumpLeft;
        private Animation jumpRight;
        private Animation dead;
        private Animation currentAnimation;

        private Transform transform;
        private Platforms platform;
        private float speedX = 150;
        private float speedY = 150;
        private float posIni;
        private float posFinal;
        private float diffPos;

        private float jumpTime;
        private bool canJump;


        public Transform Transform => transform;
        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        //private bool is_grounded = true;

        public Character(Vector2 initialPos)
        {
            transform = new Transform(initialPos, 0, new Vector2(1.5f, 1.5f));

            idleLeft = CreateAnimation("Idle", "assets/Animations/Monkey/idle_left_", 2, 0, false);
            idleRight = CreateAnimation("Idle", "assets/Animations/Monkey/idle_right_", 2, 0, false);
            runLeft = CreateAnimation("Run Left", "assets/Animations/Monkey/walking_left_", 3, 0.06f, true);
            runRight = CreateAnimation("Run Right", "assets/Animations/Monkey/walking_right_", 3, 0.06f, true);
            jumpLeft = CreateAnimation("Jump Left", "assets/Animations/Monkey/jumping_left_", 4, 0.1f, false);
            jumpRight = CreateAnimation("Jump Right", "assets/Animations/Monkey/jumping_right_", 4, 0.1f, false);
            dead = CreateAnimation("Dead", "assets/Animations/Monkey/dying_left_", 3, 0.5f, false);

            currentAnimation = idleRight;
            //platform = Gameplay.platform;
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
            if (diffPos > 0)
            {
                currentAnimation = idleRight;
            }

            if (diffPos < 0)
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

            /*if (Engine.GetKey(Keys.W))
            {
                tiempoAire += Time.deltaTime;

                Salto(new Vector2(0, -speedY * 2));

                if(tiempoAire >= 1)
                {
                    Salto(new Vector2(0, speedY * 2));
                }
                //Move(new Vector2(0, -speedY));
                currentAnimation = jumpLeft;
            }*/

            if (Engine.GetKey(Keys.S))
            {
                Move(new Vector2(0, speedY));
                currentAnimation = jumpLeft;
            }

            currentAnimation.Update();
            if(!canJump)
                Salto(new Vector2(0, speedY * 2));  // GRAVEDAD PERPETUA
            JumpReady();
            //IsBoxColliding();
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, transform.rotation, RealWidth / 2f, RealHeight / 2f);
        }

        public bool IsBoxColliding(Platforms p_platform)
        {
            float distanceX = Math.Abs(transform.position.x - p_platform.Transform.position.x);
            float distanceY = Math.Abs(transform.position.y - p_platform.Transform.position.y);

            float sumHalfWidths = RealWidth / 2 + p_platform.RealWidth / 2;
            float sumHalfHeights = RealHeight / 2 + p_platform.RealHeight / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                canJump = true;
                return true;
                //transform.position.y = platform.RealHeight / 2; //La posicion en Y del monkey es siempre igual
            }
            canJump = false;
            return false;
        }
        public void Move(Vector2 pos)
        {
            posIni = transform.position.x;
            transform.position.x += pos.x * Time.deltaTime;
            posFinal = transform.position.x;
            diffPos = posFinal - posIni;
            transform.position.y += pos.y * Time.deltaTime;
        }

        public void Salto(Vector2 pos)
        {
            transform.position.y += pos.y * Time.deltaTime;
        }

        private void JumpReady()
        {
            if (Engine.GetKey(Keys.SPACE))
            {
                Salto(new Vector2(0, -speedY * 4));
                jumpTime += Time.deltaTime;

                Engine.Debug("QUIERO SALTAR");

                if (jumpTime > 1)
                {
                    Salto(new Vector2(0, speedY * 4));
                }
            }
        }

        public void ResetValues()
        {
            transform.position = new Vector2(600, 200);
        }

        /*public void InputDetection()
        {
            if (diffPos > 0 && is_grounded)
            {
                currentAnimation = idleRight;
            }

            if (diffPos < 0 && is_grounded)
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

                if (diffPos < 0 && is_grounded == false)
                {
                    currentAnimation = jumpLeft;
                }
            }
        }*/
    }
}
