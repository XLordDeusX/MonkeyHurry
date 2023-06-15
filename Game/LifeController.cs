using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LifeController
    {
        private int life = 3;
        private Animation idle;
        private Animation currentAnimation;
        private Transform transform;

        private List<LifeController> lifes = new List<LifeController>();

        //public delegate void GetDamageDelegate();
        //public event GetDamageDelegate onGetDamage;

        public int Life => life;
        public Transform Transform => transform;
        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;


        public LifeController(Vector2 initialPos)
        {
            transform = new Transform(initialPos, 0, new Vector2(1, 1));
            idle = CreateAnimation("Idle", "assets/UI/Mono_cabeza_", 2, 0, false);
            lifes.Add(this);
            lifes.Add(this);
            lifes.Add(this);
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

        public void GetDamage()
        {
            life -= 1;
            if (Life == 0)
            {
                GameManager.Instance.ChangeScreen(GameManager.Instance.defeat);
            }
        }
        public void Render()
        {
            for (int i = 0; i < lifes.Count; i++)
            {
                lifes[i].transform.position.x = 10 + (10 * i);
            }
            float offoset = 10;
            foreach(var life in lifes)
            {
                offoset += 10;
                Engine.Draw(currentAnimation.CurrentFrame, transform.position.x + offoset, transform.position.y, transform.scale.x, transform.scale.y, transform.rotation, RealWidth / 2f, RealHeight / 2f);
            }
            //Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, transform.rotation, RealWidth / 2f, RealHeight / 2f);
        }
    }
}
