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
        public BananaUnits bananaPoint = new BananaUnits("point", new Transform(new Vector2(0, 0), 0, new Vector2(1, 1)));
        public TransparentBanana bananaTrans = new TransparentBanana("trans", new Transform(new Vector2(0, 0), 0, new Vector2(1, 1)));
        
        public static Character monkey;
        public static Background background;
        public static Lava lava;
        public static Banana banana;

        static GenericPool<Banana> bananaPool = new GenericPool<Banana>();
        public static GenericPool<Platforms> platformsPool = new GenericPool<Platforms>();
        //static List<Platforms> platforms = new List<Platforms>();
        static List<LifeUnits> lifes = new List<LifeUnits>();
        static List<BananaUnits> bananaPoints = new List<BananaUnits>();
        static List<TransparentBanana> bananasTrans = new List<TransparentBanana>();

        readonly int lifeOffset = 25;
        readonly int bananaOffset = 300;

        public event Action<GameObject,GameObject> OnCollisionEnter;

        public override void Start() 
        {
            background = new Background("background", new Transform(new Vector2(500, -1500), 0, new Vector2(1, 1)));

            lifes.Add(new LifeUnits("vida", new Transform(new Vector2(lifeOffset, 25), 0, new Vector2(1, 1))));
            lifes.Add(new LifeUnits("vida", new Transform(new Vector2(lifeOffset + (life.RealWidth), 25), 0, new Vector2(1, 1))));
            lifes.Add(new LifeUnits("vida", new Transform(new Vector2(lifeOffset + (life.RealWidth * 2), 25), 0, new Vector2(1, 1))));

            bananasTrans.Add(new TransparentBanana("trans", new Transform(new Vector2(bananaOffset, 25), -30, new Vector2(0.35f, 0.35f))));
            bananasTrans.Add(new TransparentBanana("trans", new Transform(new Vector2(bananaOffset + (bananaPoint.RealWidth / 2), 25), -30, new Vector2(0.35f, 0.35f))));
            bananasTrans.Add(new TransparentBanana("trans", new Transform(new Vector2(bananaOffset + (bananaPoint.RealWidth), 25), -30, new Vector2(0.35f, 0.35f))));

            bananaPoints.Add(new BananaUnits("punto", new Transform(new Vector2(bananaOffset, 25), -30, new Vector2(0.35f, 0.35f))));
            bananaPoints.Add(new BananaUnits("punto", new Transform(new Vector2(bananaOffset + (bananaPoint.RealWidth/2), 25), -30, new Vector2(0.35f, 0.35f))));
            bananaPoints.Add(new BananaUnits("punto", new Transform(new Vector2(bananaOffset + (bananaPoint.RealWidth), 25), -30, new Vector2(0.35f, 0.35f))));

            bananaPool.AddNewUsedObj(new Banana("banana", new Transform(new Vector2(400, 300), 0, new Vector2(0.3f, 0.3f))));

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

            foreach (var banana in bananaPool.GetUsedObjs())
            {
                if (monkey.IsBoxColliding(banana))
                {
                    for (int i = 1; i < bananasTrans.Count; i++)
                    {
                        bananasTrans.RemoveAt(i - 1);
                    }

                    Random bananaPosX = new Random();
                    var posX = bananaPosX.Next(100, 800);
                    banana.transform.position.x = posX;

                    Random bananaPosY = new Random();
                    var posY = bananaPosY.Next(100, 500);
                    banana.transform.position.y = posY;

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
            
            foreach (var point in bananaPoints)
            {
                point.Render();
            }
            
            foreach (var point in bananasTrans)
            {
                point.Render();
            }

            Engine.Show();
        }
    }
}