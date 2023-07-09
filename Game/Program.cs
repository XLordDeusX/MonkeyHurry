using System;
using System.Collections.Generic; 
using System.Media;

namespace Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine.Initialize();
            Initialization();


            while (true)
            {
                Update();
                Render();
            }
        }

        private static void Initialization()
        {
            GameManager.Instance.StartScreen();
        }
        private static void Update()
        {
            GameManager.Instance.Update();
        }
        private static void Render()
        {
            GameManager.Instance.Render();
        }
    }
}