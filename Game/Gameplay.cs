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
        public LifeUnits life = new LifeUnits("life", new Transform(new Vector2(0, 0), 0, new Vector2(1, 1)));
        public static Character monkey;
        public static Background background;
        public static Lava lava;

        static GenericPool<Banana> bananaPool = new GenericPool<Banana>();
        public static GenericPool<Platforms> platformsPool = new GenericPool<Platforms>();
        //static List<Platforms> platforms = new List<Platforms>();
        static List<LifeUnits> lifes = new List<LifeUnits>();

        readonly int offset = 25;

        public event Action<GameObject,GameObject> OnCollisionEnter;

        public override void Start() 
        {
            background = new Background("background", new Transform(new Vector2(500, -1500), 0, new Vector2(1, 1)));

            lifes.Add(new LifeUnits("vida", new Transform(new Vector2(offset, 25), 0, new Vector2(1, 1))));
            lifes.Add(new LifeUnits("vida", new Transform(new Vector2(offset + (life.RealWidth), 25), 0, new Vector2(1, 1))));
            lifes.Add(new LifeUnits("vida", new Transform(new Vector2(offset + (life.RealWidth * 2), 25), 0, new Vector2(1, 1))));

            monkey = new Character("monkey", new Transform(new Vector2(700, -500), 0, new Vector2(1.5f, 1.5f)));

            platformsPool.AddNewUsedObj(new Platforms("platform", new Transform(new Vector2(700, 100), 0, new Vector2(1, 1))));
            platformsPool.AddNewUsedObj(new Platforms("platform", new Transform(new Vector2(600, 220), 0, new Vector2(1, 1))));
            platformsPool.AddNewUsedObj(new Platforms("platform", new Transform(new Vector2(550, 340), 0, new Vector2(1, 1))));
            platformsPool.AddNewUsedObj(new Platforms("platform", new Transform(new Vector2(350, 460), 0, new Vector2(1, 1))));
            platformsPool.AddNewUsedObj(new Platforms("platform", new Transform(new Vector2(500, 580), 0, new Vector2(1, 1))));
            platformsPool.AddNewUsedObj(new Platforms("platform", new Transform(new Vector2(700, 650), 0, new Vector2(1, 1))));

            lava = new Lava("lava", new Transform(new Vector2(478, 1150), 0, new Vector2(1, 1)));

            GameManager.Instance.soundPlayer = new SoundPlayer("assets/Sounds/gameplay.wav");
            GameManager.Instance.soundPlayer.PlayLooping();

            time.InitializedTime();
        }
        public override void Update() 
        {
            lava.Update();
            monkey.Update();

            foreach (var platform in platformsPool.GetUsedObjs())
            {
                if (lava.IsBoxColliding(platform))
                {
                    OnCollisionEnter?.Invoke(lava, platform);

                    Random platformPosX = new Random();
                    var posX = platformPosX.Next(100, 800);
                    platform.transform.position.x = posX;

                    continue;
                }
            }

            foreach (var platform in platformsPool.GetUsedObjs())
            {

                if (monkey.IsBoxColliding(lava))
                {
                    OnCollisionEnter?.Invoke(monkey, lava);

                    for (int i = 1; i < lifes.Count; i++)
                    {
                        lifes.RemoveAt(lifes.Count - i);
                    }

                    break;
                }

                if (monkey.IsBoxColliding(platform)) 
                {
                    OnCollisionEnter?.Invoke(monkey, platform);
                    break; 
                }
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