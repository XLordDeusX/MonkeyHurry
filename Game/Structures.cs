using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //This part is related to the environment and platforms of the game.
    public class Structures
    {
        //private string image;
        private Transform transform;
        //private RendereableObject renderComponent;
        private float speedX = 0;
        private float speedY = 0;

        private Animation lava;
        private Animation currentAnimation;

        public Structures(Vector2 initialPos)
        {
            //image = p_image;
           // renderComponent = new RendereableObject(p_image);
            transform = new Transform(initialPos, 0, new Vector2(1,1));
            //speedX = p_speedX;
            // speedY = p_speedY;
            lava = CreateAnimation("Lava", "assets/Animations/Lava/lava_", 8, 1f);
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
