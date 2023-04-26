using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Screens
    {
        public static void MainMenu()
        {
            Engine.Clear();
            Engine.Draw();
            Engine.Show();
        }
        public static void Gameplay()
        {
            Engine.Clear();
            structures.Add(new Structures("assets/Animations/Sky.png", 0, 0, 5, 0));
            structures.Add(new Structures("assets/Animations/Lava/lava_1.png", 0, 500, 5, 0));
            structures.Add(new Structures("assets/Animations/platform.png", 50, 50, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 300, 350, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 550, 200, 0, 70));
            characters.Add(new Character("assets/Animations/Monkey/idle_1.png", 50, 50, 0, 70));
            Engine.Show();
        }
        public static void Screen3()
        {
            Engine.Clear();
            Engine.Show();
        }
        public static void Screen4()
        {
            Engine.Clear();
            Engine.Show();
        }



    }
}
