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
        private string image;
        private Transform transform;
        private RendereableObject renderComponent;
        private float speedX;
        private float speedY;

        public Structures(string p_image, float p_posX, float p_posY, float p_speedX, float p_speedY)
        {
            image = p_image;
            renderComponent = new RendereableObject(p_image);
            transform = new Transform(p_posX, p_posY);
            speedX = p_speedX;
            speedY = p_speedY;
        }

        public void Update()
        {
            transform.Move(speedX * Program.deltaTime, speedY * Program.deltaTime);
        }

        public void Render()
        {
            renderComponent.Render(transform.PosX, transform.PosY, transform.ScaleX, transform.ScaleY, transform.Rot, transform.OffsetX, transform.OffsetY);
        }
    }
}
