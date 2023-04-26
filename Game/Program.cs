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

<<<<<<< HEAD
        public static List<Structures> structures = new List<Structures>();
=======
        public static Structures platformOne;
        public static Structures platformTwo;
        public static Structures platformThree;
        public static Structures lava;
        public static Structures sky;
        public static Structures initialPlatform;

      

>>>>>>> Maru_Branch
        public static List<Character> characters = new List<Character>();
        public static List<Structures> structures = new List<Structures>();

<<<<<<< HEAD
=======

        // static Animation idle;
        //static Animation walking;
        //static Animation currentAnimation = null;
>>>>>>> Maru_Branch
        static void Main(string[] args)
        {
            Engine.Initialize();

            startTime = DateTime.Now;

<<<<<<< HEAD
            
=======
            // idle = CreateAnimation();
            //walking = CreateAnimation();
            //currentAnimation = idle;
            //currentAnimation= walking;

            structures.Add(new Structures("assets/Animations/Sky.png", 0, 0, 0, 0));
            structures.Add(new Structures("assets/Animations/platform.png", 50, 50, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 300, 100, 0, 70));
            structures.Add(new Structures("assets/Animations/platform.png", 550, 200, 0, 70));
            characters.Add(new Character("assets/Animations/Monkey/idle_1.png", 350, 351, 0, 0));

>>>>>>> Maru_Branch
            while (true)
            {
                //Engine.Clear();
                if (Engine.GetKey(Keys.N))
                {
                    Engine.Clear();
                    Sarasa();
                    
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
<<<<<<< HEAD

=======
>>>>>>> Maru_Branch

            foreach (var structures in structures)
            {
                
                structures.Render();
            }
<<<<<<< HEAD
=======
            Engine.Draw("assets/Animations/Initial_Platform.png", 150, 230, 2.5f, 2);
            Engine.Draw("assets/Animations/Lava/lava_1.png", 0, 550, 2.5f, 1);
>>>>>>> Maru_Branch

            //Engine.Draw();

            foreach (var character in characters)
            {
                
                character.Render();
            }
<<<<<<< HEAD
=======
            //Engine.Draw("assets/Animations/platform.png", 0, 45, 1.5f, 1.5f);
            //Engine.Draw("assets/Animations/Monkey/idle_1.png", 40, 0, 2, 2);

>>>>>>> Maru_Branch

            Engine.Show();
        }

        private static void DeltaCalculations()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
        }
<<<<<<< HEAD
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
=======

        /* private static Animation CreateAnimation()
         {
             // Idle Animation
             List<Texture> idleFrames = new List<Texture>();
             List<Texture> walkingFrames = new List<Texture>();

             for (int i = 0; i < 4; i++)
             {
                 idleFrames.Add(Engine.GetTexture($"{i}.png"));
             }
             for (int i = 0; i < 9; i++)
             {
                 walkingFrames.Add(Engine.GetTexture($"{i}.png"));
             }

             Animation idleAnimation = new Animation("idle_", idleFrames 2, true);
             Animation walkingAnimation = new Animation("walking_", walkingFrames, 2, true);

             return idleAnimation;
             return walkingAnimation;
         }*/
    }
}


    
>>>>>>> Maru_Branch
