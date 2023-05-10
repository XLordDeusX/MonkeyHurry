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

        static SoundPlayer soundPlayer = new SoundPlayer("assets/Sounds/menu.wav");
        

        static bool gameplay = false;
        static void Main(string[] args)
        {
            Engine.Initialize();

            startTime = DateTime.Now;

            SetLevel();

            while (true)
            {
                InputUpdate();
                Movement();
                Draw();
                //DeltaCalculations();
            }
        }

        private static void SetLevel()
        {
            monkey = new Character(new Vector2(600, 400));
            lava = new Structures(new Vector2(0, 500));
            structures.Add(lava);
            characters.Add(monkey);
            soundPlayer.PlayLooping();
        }

        private static void InputUpdate()
        {
            if (Engine.GetKey(Keys.N))
            {
                gameplay = true;
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

            if (gameplay == false)
            {
                Engine.Clear();
                Engine.Draw("assets/Screens/Menu.png", 0, 0, 1.055f, 1.55f, 0, 0, 0);
                Engine.Show();
            }

            if (gameplay == true)
            {
                Engine.Clear();
                

                soundPlayer = new SoundPlayer("assets/Sounds/gameplay.wav");
                soundPlayer.PlayLooping();

                Engine.Draw("assets/Animations/Sky.png", 0, 0, 1.2f, 1.55f, 0, 0, 0);
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