using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //This part is related to the main character
    public class Character : GameObject, IRenderizable
    {
        private Animation idleLeft;
        private Animation idleRight;
        private Animation runLeft;
        private Animation runRight;
        private Animation jumpLeft;
        private Animation jumpRight;
        private Animation dead;

        private float speedX = 150;
        private float posIniX;
        private float posFinalX;
        private float diffPosX;


        private float speedY = 150;
        private float posIniY;
        private float posFinalY;
        private float diffPosY;

        private float jumpTime;
        private bool canJump;

        private LifeController monkeyLife = new LifeController(new Vector2(0, 0));

        //public event Action OnDie;


        public Character(string p_name, Transform p_transform) : base(p_name, p_transform)
        {   
            idleLeft = CreateAnimation("Idle", "assets/Animations/Monkey/idle_left_", 2, 0, false);
            idleRight = CreateAnimation("Idle", "assets/Animations/Monkey/idle_right_", 2, 0, false);
            runLeft = CreateAnimation("Run Left", "assets/Animations/Monkey/walking_left_", 3, 0.06f, true);
            runRight = CreateAnimation("Run Right", "assets/Animations/Monkey/walking_right_", 3, 0.06f, true);
            jumpLeft = CreateAnimation("Jump Left", "assets/Animations/Monkey/jumping_left_", 4, 0.1f, false);
            jumpRight = CreateAnimation("Jump Right", "assets/Animations/Monkey/jumping_right_", 4, 0.1f, false);
            dead = CreateAnimation("Dead", "assets/Animations/Monkey/dying_left_", 3, 0.5f, false);
            currentAnimation = idleRight;
            RenderizablesManager.Instance.AddObjet(this);
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
            InputDetection();

            currentAnimation.Update();
            if (!canJump)
            {
                Salto(new Vector2(0, speedY * 3));  // GRAVEDAD PERPETUA
            }
            JumpReady();
            ScreenCrossing();
        }

        public bool IsBoxColliding(GameObject p_obj)
        {
            float distanceX = Math.Abs(transform.position.x - p_obj.transform.position.x);
            float distanceY = Math.Abs(transform.position.y - p_obj.transform.position.y);

            float sumHalfWidths = RealWidth / 2 + p_obj.RealWidth / 2;
            float sumHalfHeights = RealHeight / 2 + p_obj.RealHeight / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                if(p_obj.name == "platform")
                {
                    canJump = true;
                    jumpTime = 0;
                }
                else
                {
                    monkeyLife.GetDamage(1);
                    ResetValues();
                }
              
                return true;
            }
            canJump = false;
            return false;
        }

        public void Move(Vector2 pos)
        {
            posIniX = transform.position.x;
            transform.position.x += pos.x * Time.deltaTime;
            posFinalX = transform.position.x;
            diffPosX = posFinalX - posIniX;
        }

        public void Salto(Vector2 pos)
        {
            posIniY = transform.position.y;
            transform.position.y += pos.y * Time.deltaTime;
            posFinalY = transform.position.y;
            diffPosY = posFinalY - posIniY;
        }

        private void JumpReady()
        {
            if (Engine.GetKey(Keys.SPACE))
            {
                Salto(new Vector2(0, -speedY * 5));
                
                jumpTime += Time.deltaTime;

                if (jumpTime > 0.4f)
                {
                    Salto(new Vector2(0, speedY * 5));
                }
            }
        }

        public void ScreenCrossing()
        {
            if(transform.position.x > 950)
            {
                transform.position.x = 10;
            }

            if(transform.position.x < 0)
            {
                transform.position.x = 930;
            }
        }
        public void ResetValues()
        {
            transform.position = new Vector2(600, -200);
        }

        public void InputDetection()
        {
            if (diffPosX > 0 && canJump)
            {
                currentAnimation = idleRight;
            }
            else if( diffPosX > 0 && !canJump)
            {
                currentAnimation = jumpRight;
            }

            if (diffPosX < 0 && canJump)
            {
                currentAnimation = idleLeft;
            }
            else if(diffPosX < 0 && !canJump)
            {
                currentAnimation = jumpLeft;
            }

            if (Engine.GetKey(Keys.D) && canJump)
            {
                Move(new Vector2(speedX, 0));
                currentAnimation = runRight;
            }
            else if(Engine.GetKey(Keys.D) && !canJump)
            {
                Move(new Vector2(speedX, 0));
                currentAnimation = jumpRight;
            }

            if (Engine.GetKey(Keys.A) && canJump)
            {
                Move(new Vector2(-speedX, 0));
                currentAnimation = runLeft;
            }
            else if(Engine.GetKey(Keys.A) && !canJump)
            {
                Move(new Vector2(-speedX, 0));
                currentAnimation = jumpLeft;
            }
        }
    }
}
