using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LifeUnits : GameObject
    {
        private Animation idle;

        public LifeUnits(string p_name, Transform p_transform) : base(p_name, p_transform)
        {
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
    }
}
