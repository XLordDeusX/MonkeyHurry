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
        private float speedX = 0;
        private float speedY = 0;

        private Animation lava;
        private Animation currentAnimation;

        public Lava(Vector2 initialPos)
        {
            transform = new Transform(initialPos, 0, new Vector2(1, 1));
            lava = CreateAnimation("Lava", "assets/Animations/Lava/lava_", 8, 0.06f);
            currentAnimation = lava;
            currentAnimation.Reset();
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
            Move(new Vector2(speedX, speedY));
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
