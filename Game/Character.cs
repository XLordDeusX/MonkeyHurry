using System.Collections.Generic;
using System;

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


        //Animation currentAnimation = null;
        //Animation idle;
        //Animation Walking;
        
        public Character(string p_image, float p_posX, float p_posY, float p_speedX, float p_speedY)
        {
            //idle = CreateAnimation("idle_","Animations/Monkey/idle_",3,1);
            //Walking = CreateAnimation("walking_", "Animations/Monkey/walking_", 2, 2);
            image = p_image;
            transform = new Transform(p_posX, p_posY);
            renderComponent = new RendereableObject(p_image);
            speedX = p_speedX;
            speedY = p_speedY;

        }
       /* private Animation CreateAnimation(string p_animationID, string p_path,int p_textureAmount, float p_animationSpeed)
        {
            List<Texture> animationFrames = new List<Texture>();

            for(int i = 1; i < p_textureAmount; i++)
            {
                animationFrames.Add(Engine.GetTexture($"{p_path}{i}.png"));
            }

            Animation animation = new Animation(p_animationID, animationFrames, p_animationSpeed, true);
       
            return animation;

            
        }*/

        public void Update()
        {
            
            //Basic movement of the character, without gravity.
            if (Engine.GetKey(Keys.D))
            {
                transform.Move(100 * Program.deltaTime, 0);
                //currentAnimation = Walking;
            }
            else
            {
                //currentAnimation = idle;
            }
            if (Engine.GetKey(Keys.S))
            {
                transform.Move(0, 100 * Program.deltaTime);
            }
            if (Engine.GetKey(Keys.A))
            {
                transform.Move(-100 * Program.deltaTime, 0);
            }
            if (Engine.GetKey(Keys.W))
            {
                transform.Move(0, -100 * Program.deltaTime);
            }
            //transform.Move(speedX * Program.deltaTime, speedY * Program.deltaTime); 
           // currentAnimation.Update();
        }


        public void Render()
        {
            //Engine.Draw(currentAnimation.CurrentTexture,transform.PosX,transform.PosY);
            renderComponent.Render(transform.PosX, transform.PosY,transform.ScaleX,transform.ScaleY,transform.Rot,transform.OffsetX,transform.OffsetY);

        }

    }

}
