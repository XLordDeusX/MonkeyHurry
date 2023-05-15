using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //This part is related to the environment and platforms of the game.
    public class Platforms
    {
        private Transform transform;
        private Character monkey;
        private float speedX = 0;
        private float speedY = 0;

        private Animation platform;
        private Animation currentAnimation;

        public Transform Transform => transform;
        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;
        
        public Platforms(Vector2 initialPos)
        {
            transform = new Transform(initialPos, 0, new Vector2(1,1));
            platform = CreateAnimation("Platform", "assets/Animations/Platforms/platform_", 2, 0, false);
            monkey = Gameplay.monkey;
            currentAnimation = platform;
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
            float distanceX = Math.Abs(transform.position.x - monkey.Transform.position.x);
            float distanceY = Math.Abs(transform.position.y - monkey.Transform.position.y);

            float sumHalfWidths = RealWidth / 2 + monkey.RealWidth / 2;
            float sumHalfHeights = RealHeight / 2 + monkey.RealHeight / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                monkey.CanJump = true;
                //La posicion en Y del monkey es siempre igual
            }
        }

        public void Move(Vector2 pos)
        {
            transform.position.x += pos.x * Time.deltaTime;
            transform.position.y += pos.y * Time.deltaTime;
        }
    }
}
