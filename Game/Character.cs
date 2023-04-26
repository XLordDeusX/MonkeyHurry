using System.Collections.Generic;
using System;

namespace Game
{
    //This part is related to the main character
    public class Character
    {
        private float posX;
        private float posY;
        private float rot = 0f;
        private float scaleX = 2f;
        private float scaleY = 2f;
        private float offsetX = 0f;
        private float offsetY = 0f;
        private string image;

        private RendereableObject renderComponent;

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

        public Character(string p_image, float p_posX, float p_posY, float p_speedX, float p_speedY)
        {
            image = p_image;
            posX = p_posX;
            posY = p_posY;
            renderComponent = new RendereableObject(p_image);
            speedX = p_speedX;
            speedY = p_speedY;
        }
        public Character(float p_posX, float p_posY)
        {
            posX = p_posX;
            posY = p_posY;
        }

        public void Move(float x, float y)
        {
            posX += x;
            posY += y;
        }

        public void Update()
        {
            //Basic movement of the character, without gravity.
            if (Engine.GetKey(Keys.D))
            {
               Move(100 * Program.deltaTime, 0);
                
            }
            if (Engine.GetKey(Keys.S))
            {
               Move(0, 100 * Program.deltaTime);
            }
            if (Engine.GetKey(Keys.A))
            {
               Move(-100 * Program.deltaTime, 0);
            }
            if (Engine.GetKey(Keys.W))
            {
                Move(0, -100 * Program.deltaTime);
            }
            //transform.Move(speedX * Program.deltaTime, speedY * Program.deltaTime); 
           ;
        }
        public void Render()
        {
           
            renderComponent.Render(PosX,PosY,ScaleX,ScaleY,Rot,OffsetX,OffsetY);

        }
    }

}
