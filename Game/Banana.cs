using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Banana
    {
        private float _speed = 150;
        private float _posX = 0;
        private float _posY = 0;
        private bool draw = true;
        private float lifeTime = 1;
        private float timer = 0;

        private Animation currentAnimation;
        private Animation banana;
        private Transform transform;

        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        public event Action<Banana> OnDie;

        public Banana(Vector2 initialPos)
        {
            Gameplay.bananaPool.AddNewObj(this);
            OnDie += Gameplay.bananaPool.AddToPool;
            Reset(_posX,_posY);
            transform = new Transform(initialPos, 0, new Vector2(1, 1));
            banana = CreateAnimation("Banana", "assets/UI/Mono_cabeza_", 2, 0, false);
            currentAnimation = banana;
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
            if (!draw)
                return;
            _posX -= _speed * Time.deltaTime;
            timer += Time.deltaTime;
            if (timer >= lifeTime)
            {
                OnDie.Invoke(this);
                OnDie -= Gameplay.bananaPool.AddToPool;
                draw = false;
            }
            currentAnimation.Update();
        }
        public void Reset(float _posX,float _posY)
        {
            transform.position.x = _posX;
            transform.position.y = _posY;
            draw = true;
            timer = 0;
            OnDie += Gameplay.bananaPool.AddToPool;

        }
        public void Render()
        {
            if (draw)
                Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, transform.rotation, RealWidth / 2f, RealHeight / 2f);
        }

    }
}
