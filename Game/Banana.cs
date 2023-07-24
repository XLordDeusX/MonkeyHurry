using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Banana : GameObject, IMovement
    {
        private Animation banana;
        private int speedX = 500;
        private int rotSpeed = 1500;
        private float lifeTime = 3;
        private float timer = 0;

        public event Action<Banana> OnDie;

        public Banana(string p_name, Transform p_transform) : base(p_name, p_transform)
        {
            banana = CreateAnimation("Banana", "assets/Items/banana_", 2, 0, false);
            currentAnimation = banana;
            RenderizablesManager.Instance.AddObjet(this);
            GameManager.Instance.GameplayScreen.bananaPool.AddNewUsedObj(this);
            Reset(p_name, p_transform);
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
            timer += Time.deltaTime;
            Move(new Vector2(speedX, 0));
            LifeTime();
        }

        public void Move(Vector2 pos)
        {
            transform.position.x += pos.x * Time.deltaTime;
            transform.rotation += rotSpeed * Time.deltaTime;
        }

        public void LifeTime()
        {
            if (timer >= lifeTime)
            {
                OnDie?.Invoke(this);
                draw = false;
            }
        }

        public void Reset(string p_name, Transform p_transform) 
        {
            name = p_name;
            transform = p_transform;
            draw = true;
            timer = 0;
        }

        public void SetDirection(bool left)
        {
            if (left == true)
            {
                speedX *= -1;
            }
        }
    }
}
