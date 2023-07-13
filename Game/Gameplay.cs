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
        public LifeUnits life = new LifeUnits("vida", new Transform(new Vector2(0, 0), 0, new Vector2(1, 1)));
        public StarUnits starPoint = new StarUnits("punto", new Transform(new Vector2(0, 0), 0, new Vector2(1, 1)));
        public StarUI blackStar = new StarUI("black", new Transform(new Vector2(0, 0), 0, new Vector2(1, 1)));

        public Bird bird;
        public Character monkey;
        public Background background;    
        public Lava lava;
        public Banana banana;
        public GenericPool<Banana> bananaPool = new GenericPool<Banana>();
        public static GenericPool<Platforms> platformsPool = new GenericPool<Platforms>();
        //static List<Platforms> platforms = new List<Platforms>();

        //public static List<Banana> bananas = new List<Banana>();
        static List<LifeUnits> lifes = new List<LifeUnits>();
        static List<StarUnits> starPoints = new List<StarUnits>();
        static List<Star> stars = new List<Star>();
        static List<StarUI> blackStars = new List<StarUI>();

        readonly int lifeOffset = 25;
        readonly int starOffset = 850;

        public event Action<GameObject,GameObject> OnCollisionEnter;

        public override void Start() 
        {
            background = new Background("background", new Transform(new Vector2(500, -1500), 0, new Vector2(1, 1)));

            lifes.Add(new LifeUnits("vida", new Transform(new Vector2(lifeOffset, 25), 0, new Vector2(1, 1))));
            lifes.Add(new LifeUnits("vida", new Transform(new Vector2(lifeOffset + (life.RealWidth), 25), 0, new Vector2(1, 1))));
            lifes.Add(new LifeUnits("vida", new Transform(new Vector2(lifeOffset + (life.RealWidth * 2), 25), 0, new Vector2(1, 1))));

            blackStars.Add(new StarUI("blackUI", new Transform(new Vector2(starOffset, 40), -30, new Vector2(0.025f, 0.025f))));
            blackStars.Add(new StarUI("blackUI", new Transform(new Vector2(starOffset + (starPoint.RealWidth / 50), 25), 0, new Vector2(0.025f, 0.025f))));
            blackStars.Add(new StarUI("blackUI", new Transform(new Vector2(starOffset + (starPoint.RealWidth / 25), 40), 30, new Vector2(0.025f, 0.025f))));

            starPoints.Add(new StarUnits("starUI", new Transform(new Vector2(starOffset, 40), -30, new Vector2(0.025f, 0.025f))));
            starPoints.Add(new StarUnits("starUI", new Transform(new Vector2(starOffset + (starPoint.RealWidth / 50), 25), 0, new Vector2(0.025f, 0.025f))));
            starPoints.Add(new StarUnits("starUI", new Transform(new Vector2(starOffset + (starPoint.RealWidth / 25), 40), 30, new Vector2(0.025f, 0.025f))));

            bird = new Bird("bird", new Transform(new Vector2(500, 500), 0, new Vector2(0.1f, 0.1f)));

            stars.Add(new Star("star", new Transform(new Vector2(400, 300), 0, new Vector2(0.025f, 0.025f))));
            
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

            banana = BananaFactory.CreateBanana(new Transform(new Vector2(300, 400), 0, new Vector2(0.3f, 0.3f)));

            time.InitializedTime();
        }
        public override void Update() 
        {
            lava.Update();
            monkey.Update();
            bird.Update();

            foreach(var banana in bananaPool.GetUsedObjs())
            {
                banana.Update();
            }

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

            foreach (var star in stars)
            {
                if (monkey.IsBoxColliding(star))
                {
                    for (int i = 1; i < blackStars.Count; i++)
                    {
                        blackStars.RemoveAt(i - 1);
                    }

                    Random starPosX = new Random();
                    var posX = starPosX.Next(100, 800);
                    star.transform.position.x = posX;

                    Random starPosY = new Random();
                    var posY = starPosY.Next(100, 500);
                    star.transform.position.y = posY;

                    continue;
                }
            }

            foreach (var platform in platformsPool.GetUsedObjs())
            {

                if (monkey.IsBoxColliding(lava) || monkey.IsBoxColliding(bird))
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
            
            foreach(var banana in bananaPool.GetUsedObjs())
            {
                banana.Render();
            }

            foreach (var life in lifes)
            {
                life.Render();
            }
            
            foreach (var point in starPoints)
            {
                point.Render();
            }
            
            foreach (var point in blackStars)
            {
                point.Render();
            }

            Engine.Show();
        }
    }
}