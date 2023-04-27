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
        static Structures lava_2;
        static Structures lava_3;

        static List<Structures> structures = new List<Structures>();
        static List<Character> characters = new List<Character>();

        static SoundPlayer soundPlayer = new SoundPlayer("assets/Sounds/menu.wav");
        

        static bool gameplay = false;
        static void Main(string[] args)
        {
            Engine.Initialize();

            startTime = DateTime.Now;
            monkey = new Character(new Vector2(50, 50));
            lava = new Structures(new Vector2(0, 760));
            lava_2 = new Structures(new Vector2(320, 760));
            lava_3 = new Structures(new Vector2(640, 760));
            structures.Add(lava);
            structures.Add(lava_2);
            structures.Add(lava_3);
            characters.Add(monkey);
            soundPlayer.PlayLooping();

            //monkey = new Character(new Vector2(50, 50));
            //lava = new Structures(new Vector2(0, 500));
            //structures.Add(lava);
            //characters.Add(monkey);
            while (true)
            {
                InputUpdate();
                
                Movement();
                Draw();
                //DeltaCalculations();
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

        private static void InputUpdate()
        {
            if (Engine.GetKey(Keys.N))
            {
                gameplay = true;
            }
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
        private static void Sarasa()
        {
            //structures.Add(new Structures("assets/Animations/Sky.png", 0, 0, 5, 0));
            //structures.Add(lava);
            //structures.Add(new Structures("assets/Animations/platform.png", 50, 50, 0, 70));
            //structures.Add(new Structures("assets/Animations/platform.png", 300, 350, 0, 70));
            //structures.Add(new Structures("assets/Animations/platform.png", 550, 200, 0, 70));
            //structures.Add(lava);
            //characters.Add(monkey);

        }
        
    }
    
}