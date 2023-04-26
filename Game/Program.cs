using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        public static float deltaTime;
        public static DateTime startTime;
        public static float lastFrameTime;

        public static List<Structures> structures = new List<Structures>();
        public static List<Character> characters = new List<Character>();

        static void Main(string[] args)
        {
            Engine.Initialize();

            startTime = DateTime.Now;

            
            while (true)
            {
                //Engine.Clear();
                if (Engine.GetKey(Keys.N))
                {
                    Engine.Clear();
                    Sarasa();
                    Engine.Show();
                }
                if (Engine.GetKey(Keys.R))
                {
                    Engine.Clear();
                    Engine.Draw("sarasa");
                }
                Movement();
                Draw();
            }
        }

        private static void Movement()
        {
            foreach (var structures in structures)
            {
                structures.Update();
            }

            foreach (var character in characters)
            {
                character.Update();
            }

            DeltaCalculations();
        }

        private static void Draw()
        {
            Engine.Clear();


            foreach (var structures in structures)
            {
                
                structures.Render();
            }

            //Engine.Draw();

            foreach (var character in characters)
            {
                
                character.Render();
            }

            Engine.Show();
        }

        private static void DeltaCalculations()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
        }
        private static void Sarasa()
        {
            structures.Add(new Structures("assets/Animations/Sky.png", 0, 0, 5, 0));
            structures.Add(new Structures("assets/Animations/Lava/lava_1.png", 0, 500, 5, 0));
            structures.Add(new Structures("assets/Animations/platform.png", 50, 50, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 300, 350, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 550, 200, 0, 70));
            characters.Add(new Character("assets/Animations/Monkey/idle_1.png", 50, 50, 0, 70));

        }
        
    }
    
}