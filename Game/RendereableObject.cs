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
        public void Render(float posX, float posY, float scaleX, float scaleY, float rot, float offsetX, float offsetY)
        {
            Engine.Draw(image,posX,posY,scaleX,scaleY,rot,offsetX,offsetY);
        }
    }
}
