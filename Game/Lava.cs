using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Lava : GameObject
    {
        private Animation lava;
        private float speedY = 0;
        private float timerLava = -5;
        private float realTimer = -5;

        public Lava(string p_name, Transform p_tr) : base(p_name,p_tr)
        {
            lava = CreateAnimation("Lava", "assets/Animations/Lava/lava_", 8, 0.06f, true);
            currentAnimation = lava;
            currentAnimation.Reset();
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
            timerLava += Time.deltaTime;
            realTimer += Time.deltaTime;

            if(timerLava >= 3 && timerLava <= 7)
            {
                Move(new Vector2(0, -speedY));
            }
            
            if (timerLava >= 8 && timerLava <= 12)
            {
                Move(new Vector2(0, speedY));
            }

            if(timerLava >= 14)
            {
                timerLava = -5;
            }
            currentAnimation.Update();

            if (realTimer >= 40)
            {
                realTimer = -5;
                GameManager.Instance.ChangeScreen(GameManager.Instance.victory);
            }
        }

        public bool IsTouchingPlatforms(Platforms p_platform)
        {
            float distancePlatformX = Math.Abs(transform.position.x - p_platform.Transform.position.x);
            float distancePlatformY = Math.Abs(transform.position.y - p_platform.Transform.position.y);

            float sumHalfWidthsPlat = RealWidth / 2 + p_platform.RealWidth / 2;
            float sumHalfHeightsPlat = RealHeight / 2 + p_platform.RealHeight / 2;

            if (distancePlatformX <= sumHalfWidthsPlat && distancePlatformY <= sumHalfHeightsPlat)
            {
                return true;
            }

            return false;
        }

        public void Move(Vector2 pos)
        {
            transform.position.x += pos.x * Time.deltaTime;
            transform.position.y += pos.y * Time.deltaTime;
        }
    }
}
