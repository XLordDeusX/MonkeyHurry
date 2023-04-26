using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        public static float deltaTime;
        public static DateTime startTime;
        public static float lastFrameTime;

        public static Structures platformOne;
        public static Structures platformTwo;
        public static Structures platformThree;
        public static Structures lava;
        public static Structures sky;
        public static Structures initialPlatform;

        static Character monkey;

        static List<Character> characters = new List<Character>();
        public static List<Structures> structures = new List<Structures>();

        static void Main(string[] args)
        {
            Engine.Initialize();

            startTime = DateTime.Now;

            structures.Add(new Structures("assets/Animations/Sky.png", 0, 0, 0, 0));
            structures.Add(new Structures("assets/Animations/platform.png", 50, 50, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 300, 100, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 550, 200, 0, 70));
            characters.Add(new Character("assets/Animations/Monkey/idle_1.png", 350, 351, 0, 0));

            while (true)
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
            Engine.Draw("assets/Animations/Initial_Platform.png", 150, 230, 2.5f, 2);
            Engine.Draw("assets/Animations/Lava/lava_1.png", 0, 550, 2.5f, 1);

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


    