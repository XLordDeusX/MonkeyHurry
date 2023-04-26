using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Screens
    {
        public static float deltaTime;
        public static DateTime startTime;
        public static float lastFrameTime;

        public static List<Structures> structures = new List<Structures>();
        public static List<Character> characters = new List<Character>();

        public static void MainMenu()
        {
            Engine.Draw("assets/Animations/Paradigmas.png");
        }
        public static void Gameplay()
        {
            structures.Add(new Structures("assets/Animations/Sky.png", 0, 0, 5, 0));
            structures.Add(new Structures("assets/Animations/Lava/lava_1.png", 0, 500, 5, 0));
            structures.Add(new Structures("assets/Animations/platform.png", 50, 50, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 300, 350, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 550, 200, 0, 70));
            characters.Add(new Character("assets/Animations/Monkey/idle_1.png", 50, 50, 0, 70));

            foreach (var structures in structures)
            {
                structures.Update();
                structures.Render();
            }

            foreach (var character in characters)
            {
                character.Update();
                character.Render();
            }

            DeltaCalculations();


        }
        public static void Lose()
        {
            
            Engine.Draw("assets/Animations/Game_Over.png");
            
        }
        public static void Win()
        {
            
            Engine.Draw("assets/Animations/You_Won.png");
            
        }

        private static void DeltaCalculations()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
        }
    }
}
