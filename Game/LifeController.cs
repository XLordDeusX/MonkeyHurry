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
            lifes.RemoveAt(lifes.Count - 1);
            
            if (life == 0)
            {
                GameManager.Instance.ChangeScreen(GameManager.Instance.defeat);
            }

            /*switch (life)
            {
                case 2:
                    Engine.Debug(lifes.Count);
                    //lifes.RemoveAt(2);
                    lifes.Remove(this);
                    
                    break;

                case 1:
                    Engine.Debug(lifes.Count);
                    //lifes.RemoveAt(1);
                    lifes.Remove(this);
                    
                    break;

                case 0:
                    lifes.RemoveAt(0);
                    GameManager.Instance.ChangeScreen(GameManager.Instance.defeat);
                    
                    break;

                default:
                    break;
            }*/
        }
        public void Render()
        {
            for (int i = 0; i < lifes.Count; i++)
            {
                float offset = 20;
                lifes[i].transform.position.x = offset + (RealWidth * i);

                Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, transform.rotation, RealWidth / 2f, RealHeight / 2f);
            }
            /*float offset = 10;
            foreach(var life in lifes)
            {
                offset += 46;
                Engine.Draw(currentAnimation.CurrentFrame, transform.position.x + offset, transform.position.y, transform.scale.x, transform.scale.y, transform.rotation, RealWidth / 2f, RealHeight / 2f);
            }*/
        }
    }
}
