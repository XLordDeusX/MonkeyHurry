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
       // public LifeUnits life = new LifeUnits(new Vector2(0, 0));
        public static Character monkey;
        public static Background background;
        public static Lava lava;
        public static Bird bird;
        
        static List<Platforms> platforms = new List<Platforms>();
        static List<LifeUnits> lifes = new List<LifeUnits>();
        public static List<Banana> bananas = new List<Banana>();

        readonly int offset = 25;

        //public event Action<GameObject,GameObject> OnCollisionEnter;

        public override void Start() 
        {
            background = new Background("background", new Transform(new Vector2(500, -1500), 0, new Vector2(1, 1)));

            /*lifes.Add(new LifeUnits(new Vector2(offset, 25)));
            lifes.Add(new LifeUnits(new Vector2(offset + (life.RealWidth), 25)));
            lifes.Add(new LifeUnits(new Vector2(offset + (life.RealWidth * 2), 25)));*/

            monkey = new Character("monkey", new Transform(new Vector2(600, -500), 0, new Vector2(1.5f, 1.5f)));

            bird = new Bird("bird", new Transform(new Vector2(500, 500), 0, new Vector2(0.1f, 0.1f)));

            bananas.Add(new Banana("banana", new Transform(new Vector2(100, 200), 0, new Vector2(0.1f, 0.1f))));
            bananas.Add(new Banana("banana", new Transform(new Vector2(300, 300), 0, new Vector2(0.1f, 0.1f))));
            bananas.Add(new Banana("banana", new Transform(new Vector2(500, 500), 0, new Vector2(0.1f, 0.1f))));

            platforms.Add(PlatformFactory.CreatePlatforms(PlatformType.Big, new Vector2(700, 100)));
            platforms.Add(PlatformFactory.CreatePlatforms(PlatformType.Medium, new Vector2(350, 460)));
            platforms.Add(PlatformFactory.CreatePlatforms(PlatformType.Small, new Vector2(700, 650)));

            /*platforms.Add(new Platforms("platform", new Transform(new Vector2(700, 100), 0, new Vector2(1, 1))));
            platforms.Add(new Platforms("platform", new Transform(new Vector2(600, 220), 0, new Vector2(1, 1))));
            platforms.Add(new Platforms("platform", new Transform(new Vector2(550, 340), 0, new Vector2(1, 1))));
            platforms.Add(new Platforms("platform", new Transform(new Vector2(350, 460), 0, new Vector2(1, 1))));
            platforms.Add(new Platforms("platform", new Transform(new Vector2(500, 580), 0, new Vector2(1, 1))));
            platforms.Add(new Platforms("platform", new Transform(new Vector2(700, 650), 0, new Vector2(1, 1))));*/

            lava = new Lava("lava", new Transform(new Vector2(478, 1150), 0, new Vector2(1, 1)));

            GameManager.Instance.soundPlayer = new SoundPlayer("assets/Sounds/gameplay.wav");
            GameManager.Instance.soundPlayer.PlayLooping();

            time.InitializedTime();
        }

        public override void Update() 
        {
            lava.Update();
            monkey.Update();
            bird.Update();
            foreach (var banana in bananas)
            {
                if (monkey.IsBoxColliding(banana))
                {
                    Random bananaPosX = new Random();
                    var posX = bananaPosX.Next(100, 800);
                    banana.transform.position.x = posX;

                    Random bananaPosY = new Random();
                    var posY = bananaPosY.Next(100, 500);
                    banana.transform.position.y = posY;
                    continue;
                }
                
            }

           /* foreach (var platform in platforms)
            {
                if (lava.IsTouchingPlatforms(platform))
                {
                    Random platformPosX = new Random();
                    var posX = platformPosX.Next(100, 800);
                    platform.transform.position.x = posX;
                    continue;
                }
            }*/

            foreach (var platform in platforms)
            {

                if (monkey.IsBoxColliding(lava) || monkey.IsBoxColliding(bird))
                {
                    for (int i = 1; i < lifes.Count; i++)
                    {
                        lifes.RemoveAt(lifes.Count - i);
                    }
                    break;
                }
                if (monkey.IsBoxColliding(platform))
                    break;
            }
            
            if(lava.timerLava > 11)
            {
                monkey.transform.position.x = platforms[5].transform.position.x;
                monkey.transform.position.y = platforms[5].transform.position.y - 50;
            }
            
            time.Update();
        }

        public override void Render() 
        {
            Engine.Clear();

            foreach (var item in RenderizablesManager.Instance.GetObjets())
            {
                item.Render();
            }

            foreach (var life in lifes)
            {
                life.Render();
            }

            Engine.Show();
        }
    }
}