﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //This part is related to the main character
    public class Character
    {
        private string image;
        private Transform transform;
        private RendereableObject renderComponent;
        private float speedX;
        private float speedY;

        public Character(string p_image, float p_posX, float p_posY, float p_speedX, float p_speedY)
        {
            image = p_image;
            transform = new Transform(p_posX, p_posY);
            renderComponent = new RendereableObject(p_image);
            speedX = p_speedX;
            speedY = p_speedY;
        }

        public void Update()
        {
            //Basic movement of the character, without gravity.
            if (Engine.GetKey(Keys.D))
            {
                transform.Move(80 * Program.deltaTime, 0);
            }
            if (Engine.GetKey(Keys.S))
            {
                transform.Move(0, 80 * Program.deltaTime);
            }
            if (Engine.GetKey(Keys.A))
            {
                transform.Move(-80 * Program.deltaTime, 0);
            }
            if (Engine.GetKey(Keys.W))
            {
                transform.Move(0, -80 * Program.deltaTime);
            }
            //transform.Move(speedX * Program.deltaTime, speedY * Program.deltaTime); 
        }

        public void Render()
        {
            renderComponent.Render(transform.PosX, transform.PosY,transform.ScaleX,transform.ScaleY,transform.Rot,transform.OffsetX,transform.OffsetY);
        }
    }
}