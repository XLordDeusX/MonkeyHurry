using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //Everything we put in is drawn or rendered.

    public class RendereableObject
    {
        string image;

        public RendereableObject (string p_image)
        {
            image = p_image;
        }
        public void Render(Vector2 initialPos, Vector2 scale, float rot)
        {
            Engine.Draw(image,initialPos.x, initialPos.y, scale.x, scale.y, rot);
        }
    }
}
