using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LifeUnits
    {
        private Animation idle;
        private Animation currentAnimation;
        private Transform transform;

        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;


        public LifeUnits(Vector2 initialPos)
        {
            transform = new Transform(initialPos, 0, new Vector2(1, 1));
            idle = CreateAnimation("Idle", "assets/UI/Mono_cabeza_", 2, 0, false);
            currentAnimation = idle;
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

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, transform.rotation, RealWidth / 2f, RealHeight / 2f);
        }
    }
}
