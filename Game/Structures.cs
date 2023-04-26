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
        private float posX;
        private float posY;
        private float rot = 0f;
        private float scaleX = 1.5f;
        private float scaleY = 1.5f;
        private float offsetX = 0f;
        private float offsetY = 0f;
        private string image;

        private float speedX;
        private float speedY;

        //Encapsulation
        public float PosX => posX;
        public float PosY => posY;
        public float Rot => rot;
        public float ScaleX => scaleX;
        public float ScaleY => scaleY;
        public float OffsetX => offsetX;
        public float OffsetY => offsetY;

        public Structures(string p_image, float p_posX, float p_posY, float p_speedX, float p_speedY)
        {
            image = p_image;
            posX = p_posX;
            posY = p_posY;
            speedX = p_speedX;
            speedY = p_speedY;
        }

        public void  PositionStructures(float p_posX, float p_posY)
        {
            posX = p_posX;
            posY = p_posY;
        }

        public void StructureMove(float x, float y)
        {
            posX += x;
            posY += y;
        }

        public void Update()
        {
            StructureMove(speedX * Program.deltaTime, speedY * Program.deltaTime);
        }

        public void Render()
        {
            Engine.Draw(image, PosX, PosY, ScaleX,ScaleY, Rot, OffsetX,OffsetY);
        }
      
    }
}
