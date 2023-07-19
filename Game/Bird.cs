using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bird : GameObject
    {
        private Animation bird;
        private float speedX = 200;
        private float speedY = 165;
        private float regenerateTime;
        private float timerLava = -5;

        public Bird(string p_name, Transform p_transform, int p_sense) : base(p_name, p_transform)
        {
            bird = CreateAnimation("Bird", "assets/Animations/Bird/BirdSprite_", 8, 0.01f, true);
            currentAnimation = bird;
            RenderizablesManager.Instance.AddObjet(this);
            speedX = 200 * p_sense;
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
            currentAnimation.Update();
            Move(new Vector2(-speedX, 0));
            ScreenCrossing();
            RegenerateBird();
            BirdMovement();
        }

        public bool IsBoxColliding(GameObject p_obj)
        {
            float distanceX = Math.Abs(transform.position.x - p_obj.transform.position.x);
            float distanceY = Math.Abs(transform.position.y - p_obj.transform.position.y);

            float sumHalfWidths = RealWidth / 2 + p_obj.RealWidth / 2;
            float sumHalfHeights = RealHeight / 2 + p_obj.RealHeight / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                if (p_obj.name == "banana")
                {
                    DeadBird();
                }
                
                return true;
            }

            return false;
        }
        public void BirdMovement()
        {
            timerLava += Time.deltaTime;

            if (timerLava >= 2.5f && timerLava <= 5)
            {
                Move(new Vector2(0, -speedY));
            }

            if (timerLava >= 6.2f && timerLava <= 8.7f)
            {
                Move(new Vector2(0, speedY));
            }

            if (timerLava >= 10.5f)
            {
                timerLava = -1;
            }
        }
        public void Move(Vector2 pos)
        {
            transform.position.x += pos.x * Time.deltaTime;
            transform.position.y += pos.y * Time.deltaTime;
        }
        public void ScreenCrossing()
        {
            if (transform.position.x > 950)
            {
                transform.position.x = 10;
            }

            if (transform.position.x < 0)
            {
                transform.position.x = 930;
            }
        }
        public void RegenerateBird()
        {
            if (draw == false)
            {
                regenerateTime += Time.deltaTime;

                if (regenerateTime > 5)
                {
                    draw = true;
                    speedX = 200;
                    speedY = 165;
                    transform.position.y = transform.position.y - 2000;
                    regenerateTime = 0;
                }

            }
        }
        public void DeadBird()
        {
            draw = false;
            transform.position.y = transform.position.y + 2000;
        }
    }
}
