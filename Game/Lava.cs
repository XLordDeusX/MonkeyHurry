using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Lava
    {
        private Transform transform;
        private Character monkey;
        private float speedX = 0;
        private float speedY = 0;

        private Animation lava;
        private Animation currentAnimation;

        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        public Lava(Vector2 initialPos)
        {
            transform = new Transform(initialPos, 0, new Vector2(1, 1));
            lava = CreateAnimation("Lava", "assets/Animations/Lava/lava_", 8, 0.06f, true);
            monkey = Gameplay.monkey;
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
            Move(new Vector2(speedX, speedY));
            currentAnimation.Update();
            IsBoxColliding();
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, transform.rotation, RealWidth / 2f, RealHeight / 2f);
        }

        public void IsBoxColliding()
        {
            float distanceMonkeyX = Math.Abs(transform.position.x - monkey.Transform.position.x);
            float distanceMonkeyY = Math.Abs(transform.position.y - monkey.Transform.position.y);

            //float distancePlatformX = Math.Abs(transform.position.x - platform.Transform.position.x);
            //float distancePlatformY = Math.Abs(transform.position.y - platform.Transform.position.y);

            float sumHalfWidths = RealWidth / 2 + monkey.RealWidth / 2;
            float sumHalfHeights = RealHeight / 2 + monkey.RealHeight / 2;

            //float sumHalfWidthsPlat = RealWidth / 2 + platform.RealWidth / 2;
            //float sumHalfHeightsPlat = RealHeight / 2 + platform.RealHeight / 2;

            if (distanceMonkeyX <= sumHalfWidths && distanceMonkeyY <= sumHalfHeights)
            {
                Engine.Debug("SE MURIO");
                GameManager.Instance.ChangeScreen(GameManager.Instance.defeat);
                //monkey.ResetValues();
            }

            //if (distancePlatformX <= sumHalfWidthsPlat && distancePlatformY <= sumHalfHeightsPlat)
            //{
            //    Engine.Debug("Colisiona");
            //}
        }

        public void Move(Vector2 pos)
        {
            transform.position.x += pos.x * Time.deltaTime;
            transform.position.y += pos.y * Time.deltaTime;
        }
    }
}
