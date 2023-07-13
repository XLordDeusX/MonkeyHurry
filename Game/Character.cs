using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //This part is related to the main character
    public class Character : GameObject, IDamageable
    {
        private Animation idleLeft;
        private Animation idleRight;
        private Animation runLeft;
        private Animation runRight;
        private Animation jumpLeft;
        private Animation jumpRight;
        //private Animation dead;

        private float speedX = 300;
        private float posIniX;
        private float posFinalX;
        private float diffPosX;

        private float speedY = 130;
        private float posIniY;
        private float posFinalY;
        private float diffPosY;

        private float jumpTime;
        private bool canJump;

        private Banana banana = new Banana("banana", new Transform(new Vector2(0, 0), 0, new Vector2(0, 0)));
        private int starPoint = 1;
        private int starGoal = 0;
        private int hitDamage = 1;
        private int lifePoints = 3;
        private bool isDestroyed = false;
        bool left = false;


        public int BananaGoal => starGoal;
        public int LifePoints => lifePoints;
        public bool IsDestroyed
        {
            get => isDestroyed;
            set => isDestroyed = value;
        }
        public event OnLifeChanged OnLifeChanged;
        public event OnDestroyed OnDestroyed;


        public Character(string p_name, Transform p_transform) : base(p_name, p_transform)
        {   
            idleLeft = CreateAnimation("Idle", "assets/Animations/Monkey/idle_left_", 2, 0, false);
            idleRight = CreateAnimation("Idle", "assets/Animations/Monkey/idle_right_", 2, 0, false);
            runLeft = CreateAnimation("Run Left", "assets/Animations/Monkey/walking_left_", 3, 0.06f, true);
            runRight = CreateAnimation("Run Right", "assets/Animations/Monkey/walking_right_", 3, 0.06f, true);
            jumpLeft = CreateAnimation("Jump Left", "assets/Animations/Monkey/jumping_left_", 4, 0.1f, false);
            jumpRight = CreateAnimation("Jump Right", "assets/Animations/Monkey/jumping_right_", 4, 0.1f, false);
            //dead = CreateAnimation("Dead", "assets/Animations/Monkey/dying_left_", 3, 0.5f, false);
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
                
                if (p_obj.name == "lava")
                {
                    GetDamage(hitDamage);
                    ResetValues();
                }

                if(p_obj.name == "bird")
                {
                    GetDamage(hitDamage);
                    ResetValues();
                }

                if(p_obj.name == "star")
                {
                    GetStar(starPoint);
                }

                return true;
            }

            canJump = false;
            return false;
        }

        public void ShootBanana()
        {
            var banana = BananaFactory.CreateBanana(new Transform(new Vector2(transform.position.x, transform.position.y), -90, new Vector2(0.3f, 0.3f)));

            if (left == true)
            {
                banana.SetDirection(left);
            }

            banana.Reset("banana", new Transform(new Vector2(transform.position.x, transform.position.y), -90, new Vector2(0.3f, 0.3f)));
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
                Salto(new Vector2(0, -speedY * 6.5f));
                
                jumpTime += Time.deltaTime;

                if (jumpTime > 0.4f)
                {
                    Salto(new Vector2(0, speedY * 6.5f));
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
            transform.position = new Vector2(700, -200);
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
                left = false;
            }
            else if(Engine.GetKey(Keys.D) && !canJump)
            {
                Move(new Vector2(speedX, 0));
                currentAnimation = jumpRight;
                left = false;
            }

            if (Engine.GetKey(Keys.A) && canJump)
            {
                Move(new Vector2(-speedX, 0));
                currentAnimation = runLeft;
                left = true;
            }
            else if(Engine.GetKey(Keys.A) && !canJump)
            {
                Move(new Vector2(-speedX, 0));
                currentAnimation = jumpLeft;
                left = true;
            }

            if (Engine.GetKey(Keys.K))
            {
                ShootBanana();
            }
        }
        
        public void GetDamage(int p_damage)
        {
            lifePoints -= p_damage;
            OnLifeChanged?.Invoke(lifePoints);

            if (lifePoints <= 0)
            {
                Destroy();
                GameManager.Instance.ChangeScreen(GameManager.Instance.defeat);
            }
        }

        public void GetStar(int p_point)
        {
            starGoal += p_point;

            if(starGoal >= 3)
            {
                GameManager.Instance.ChangeScreen(GameManager.Instance.victory);
            }
        }

        public void Destroy()
        {
            IsDestroyed = true;
            OnDestroyed?.Invoke(this);
        }
    }
}
