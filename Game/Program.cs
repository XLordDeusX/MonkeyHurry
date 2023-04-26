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

        static Character monkey;
        static Structures lava;

        static List<Structures> structures = new List<Structures>();
        static List<Character> characters = new List<Character>();

        static void Main(string[] args)
        {
            Engine.Initialize();

            startTime = DateTime.Now;
            SoundPlayer soundPlayer = new SoundPlayer("assets/Sounds/menu.wav");
            soundPlayer.PlayLooping();

            monkey = new Character(new Vector2(50, 50));
            lava = new Structures(new Vector2(0, 500));
            while (true)
            {
                //Engine.Clear();
                if (Engine.GetKey(Keys.N))
                {
                    soundPlayer = new SoundPlayer("assets/Sounds/gameplay.wav");
                    soundPlayer.PlayLooping();
                    Engine.Clear();
                    Sarasa();
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
        private static void Sarasa()
        {
            //structures.Add(new Structures("assets/Animations/Sky.png", 0, 0, 5, 0));
            structures.Add(lava);
            //structures.Add(new Structures("assets/Animations/platform.png", 50, 50, 0, 70));
            //structures.Add(new Structures("assets/Animations/platform.png", 300, 350, 0, 70));
            //structures.Add(new Structures("assets/Animations/platform.png", 550, 200, 0, 70));
            characters.Add(monkey);

        }
        
    }
    
}