using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Platforms : GameObject
    {
        private Animation platform;

        public event Action<Platforms> OnDie;

        public Transform Transform => transform;
        
        public Platforms(string p_name, Transform p_transform) : base(p_name, p_transform)
        {
            Gameplay.platformsPool.AddNewUsedObj(this);

            platform = CreateAnimation("Platform", "assets/Animations/Platforms/platform_", 2, 0, false);
            currentAnimation = platform;
            RenderizablesManager.Instance.AddObjet(this);
            //Reset(p_name, p_transform);   
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
        
        public void Reset(string p_name, Transform p_transform)
        {
            name = p_name;
            transform = p_transform;
            draw = true;
        }
    }
}
