using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    public class Gameplay : Level 
    {
        public Time time = new Time();
        public static Character monkey;
        public static Lava lava;
        public static Platforms platform;

        static List<Platforms> platforms = new List<Platforms>(); 
        static List<Lava> lavas = new List<Lava>(); 
        static List<Character> characters = new List<Character>();
        
        public override void Start() 
        {
            monkey = new Character(new Vector2(600, 200));
            lava = new Lava(new Vector2(478, 1150));
            platform = new Platforms(new Vector2(600, 500));
            platforms.Add(platform);
            platforms.Add(new Platforms(new Vector2(700, 600)));
            lavas.Add(lava);
            characters.Add(monkey);
            GameManager.Instance.soundPlayer = new SoundPlayer("assets/Sounds/gameplay.wav");
            GameManager.Instance.soundPlayer.PlayLooping();
            time.InitializedTime();
        }
        public override void Update() 
        {
            foreach (var lava in lavas)
            {
                lava.Update();
            }

            foreach (var character in characters)
            {
                character.Update();
            }

            foreach (var platform in platforms)
            {
                platform.Update();
            }

            foreach (var platform in platforms)
            {
                if (characters[0].IsBoxColliding(platform))
                {
                    break;
                }
            }
            time.Update();
        }
        public override void Render() 
        {
            Engine.Clear();

            Engine.Draw("assets/Animations/Sky.png", 0, 0, 1.2f, 1.55f, 0, 0, 0);

            foreach (var lava in lavas)
            {
                lava.Render();
            }

            foreach (var character in characters)
            {
                character.Render();
            }

            foreach (var platform in platforms)
            {
                platform.Render();
            }

            Engine.Show();
        }
    }
}
