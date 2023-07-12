using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bird: GameObject
    {
        private Animation bird;
        private float speedX = 200;

        public Bird(string p_name, Transform p_transform) : base(p_name, p_transform)
        {
            bird = CreateAnimation("Bird", "assets/Animations/Bird/BirdSprite_", 8, 0.01f, true);
            currentAnimation = bird;
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
            currentAnimation.Update();
            Move(new Vector2(-speedX, 0));
            ScreenCrossing();
        }

        public void Move(Vector2 pos)
        {
            transform.position.x += pos.x * Time.deltaTime;
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
    }
}
