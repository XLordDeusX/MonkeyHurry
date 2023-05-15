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

        static SoundPlayer soundPlayer = new SoundPlayer("assets/Sounds/menu.wav");


        public override void Start() 
        {
            monkey = new Character(new Vector2(600, 200));
            lava = new Lava(new Vector2(478, 1150));
            platform = new Platforms(new Vector2(500, 200));
            platforms.Add(platform);
            lavas.Add(lava);
            characters.Add(monkey);
            //soundPlayer.PlayLooping();
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
            time.Update();
        }
        public override void Render() 
        {
            Engine.Clear();

            soundPlayer = new SoundPlayer("assets/Sounds/gameplay.wav");
            //soundPlayer.PlayLooping();

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
