using System;
using System.Collections.Generic;

namespace Game
{
    public class Structures
    {
        private string image;
        private float posX;
        private float posY;
        private float rot = 0f;
        private float scaleX = 1.5f;
        private float scaleY = 1.5f;
        private float offsetX = 0f;
        private float offsetY = 0f;


        private float speedX;
        private float speedY;

        public Structures(string p_image, float p_posX, float p_posY, float p_speedX, float p_speedY)
        {
            image = p_image;
            posX = p_posX;
            posY = p_posY;
            speedX = p_speedX;
            speedY = p_speedY;
        }

        public void Update()
        {
            posX += speedX * Program.deltaTime;
            posY += speedY * Program.deltaTime;
        }

        public void Render()
        {
            Engine.Draw(image, posX, posY, scaleX, scaleY, rot, offsetX, offsetY);
        }
    }

    public class Character
    {
        private string image;
        private float posX;
        private float posY;
        private float rot = 0f;
        private float scaleX = 2f;
        private float scaleY = 2f;
        private float offsetX = 0f;
        private float offsetY = 0f;


        private float speedX;
        private float speedY;

        public Character(string p_image, float p_posX, float p_posY, float p_speedX, float p_speedY)
        {
            image = p_image;
            posX = p_posX;
            posY = p_posY;
            speedX = p_speedX;
            speedY = p_speedY;
        }

        public void Update()
        {
            posX += speedX * Program.deltaTime;
            posY += speedY * Program.deltaTime;
        }

        public void Render()
        {
            Engine.Draw(image, posX, posY, scaleX, scaleY, rot, offsetX, offsetY);
        }
    }

    public class Program
    {
        public static float deltaTime;
        public static DateTime startTime;
        public static float lastFrameTime;

        public static List<Structures> structures = new List<Structures>();

        public static Structures platformOne;
        public static Structures platformTwo;
        public static Structures platformThree;
        public static Structures lava;

        public static List<Character> characters = new List<Character>();

        public static Character monkey;

        static void Main(string[] args)
        {
            Engine.Initialize();

            startTime = DateTime.Now;

            structures.Add(new Structures("assets/Animations/platform.png", 50, 50, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 300, 350, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 550, 200, 0, 70));
            characters.Add(new Character("assets/Animations/Monkey/idle_1.png", 100, 10, 0, 70));

            while(true)
            {
                Update();
                Render();
            }
        }

        private static void Update()
        {
            foreach (var structure in structures)
            {
                structure.Update();
            }

            foreach (var character in characters)
            {
                character.Update();
            }

            DeltaCalculations();
        }

        private static void Render()
        {
            Engine.Clear();
            

            foreach (var structures in structures)
            {
                structures.Render();
            }
            
            Engine.Draw("assets/Animations/Lava/lava_1.png", 0, 500, 2.5f, 1);

            foreach (var characters in characters)
            {
                characters.Render();
            }
            //Engine.Draw("assets/Animations/platform.png", 0, 45, 1.5f, 1.5f);
            //Engine.Draw("assets/Animations/Monkey/idle_1.png", 40, 0, 2, 2);
            
            Engine.Show();
        }

        private static void DeltaCalculations()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
        }
    }
}