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
                Engine.Clear();
                /*Engine.Draw("assets/Animations/Paradigmas.png");
                Engine.Draw("assets/Animations/Game_Over.png");
                Engine.Draw("assets/Animations/You_Won.png");*/
                if (Engine.GetKey(Keys.Q))
                {
                    Engine.Clear();
                    Engine.Draw("assets/Animations/Paradigmas.png");
                    Engine.Show();
                    
                }
                if (Engine.GetKey(Keys.N))
                {
                    Engine.Clear();
                    Gameplay();
                    Engine.Show();
                    
                }
                if (Engine.GetKey(Keys.Y))
                {
                    Engine.Clear();
                    Engine.Draw("assets/Animations/You_Won.png");
                    Engine.Show();
                    
                }
                if (Engine.GetKey(Keys.U))
                {
                    Engine.Clear();
                    Engine.Draw("assets/Animations/Game_Over.png");
                    Engine.Show();
                    
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
        public static void Gameplay()
        {
            structures.Add(new Structures("assets/Animations/Sky.png", 0, 0, 0, 0));
            structures.Add(new Structures("assets/Animations/Lava/lava_1.png", 0, 500, 0, 0));
            structures.Add(new Structures("assets/Animations/platform.png", 50, 50, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 300, 350, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 550, 200, 0, 70));
            characters.Add(new Character("assets/Animations/Monkey/idle_1.png", 50, 50, 0, 70));
        }
        public static void MainMenu()
        {
            
            Engine.Draw("assets/Animations/Paradigmas.png");
        }
        public static void Lose()
        {
            Engine.Draw("assets/Animations/Game_Over.png");
        }
        public static void Win()
        {
            Engine.Draw("assets/Animations/You_Won.png");
        }
    }
    
}