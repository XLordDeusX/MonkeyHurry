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
        private TransformStructures transformStructures;

        private float speedX;
        private float speedY;

        public Structures(string p_image, float p_posX, float p_posY, float p_speedX, float p_speedY)
        {
            image = p_image;
            transformStructures = new TransformStructures(p_posX, p_posY);
            speedX = p_speedX;
            speedY = p_speedY;
        }

        public void Update()
        {
            transformStructures.StructureMove(speedX * Program.deltaTime, speedY * Program.deltaTime);
        }

        public void Render()
        {
            Engine.Draw(image, transformStructures.PosX, transformStructures.PosY, transformStructures.ScaleX, transformStructures.ScaleY, transformStructures.Rot, transformStructures.OffsetX, transformStructures.OffsetY);
        }
        public bool IsBoxColliding(Transform p_ObjectC)
        {
            float distanceX = Math.Abs(transformStructures.PosX - p_ObjectC.PosX);
            float distanceY = Math.Abs(transformStructures.PosY - p_ObjectC.PosY);

            float sumHalfWidths = transformStructures.ScaleX / 2 + p_ObjectC.ScaleX / 2;
            float sumHalfHights = transformStructures.ScaleY / 2 + p_ObjectC.ScaleY / 2;

            return distanceX <= sumHalfWidths && distanceY <= sumHalfHights;
        }
    }
}
