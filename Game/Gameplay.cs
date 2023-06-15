using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    public class GameObject
    {
        public string name;
        public Transform transform;
        protected Animation currentAnimation;

        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        public GameObject(string p_name, Transform p_trns)
        {
            name = p_name;
            transform = p_trns;
        }
    }
    public class Gameplay : Level 
    {
        public Time time = new Time();
        public LifeController life; 
        public static Character monkey;
        public Lava lava;

        static List<Platforms> platforms = new List<Platforms>();
        static List<LifeController> lifes = new List<LifeController>();


        public event Action<GameObject,GameObject> OnCollisionEnter;

        public override void Start() 
        {
            lifes.Add(new LifeController(new Vector2(0, 25)));
            monkey = new Character("monkey", new Transform(new Vector2(600,-500), 0, new Vector2(1.5f, 1.5f)));

            
            lava = new Lava("lava", new Transform(new Vector2(478, 1150),0,new Vector2(1,1)));

            platforms.Add(new Platforms("platform", new Transform(new Vector2(700, 100), 0, new Vector2(1, 1))));
            platforms.Add(new Platforms("platform", new Transform(new Vector2(550, 250), 0, new Vector2(1, 1))));
            platforms.Add(new Platforms("platform", new Transform(new Vector2(350, 350), 0, new Vector2(1, 1))));
            platforms.Add(new Platforms("platform", new Transform(new Vector2(500, 500), 0, new Vector2(1, 1))));
            platforms.Add(new Platforms("platform", new Transform(new Vector2(700, 650), 0, new Vector2(1, 1))));
            
            GameManager.Instance.soundPlayer = new SoundPlayer("assets/Sounds/gameplay.wav");
            GameManager.Instance.soundPlayer.PlayLooping();
            time.InitializedTime();
        }
        public override void Update() 
        {
            lava.Update();
            monkey.Update();

            foreach (var platform in platforms)
            {
                platform.Update();
            }

            foreach (var platform in platforms)
            {
                if (lava.IsTouchingPlatforms(platform))
                {
                    Random platformPosX = new Random();
                    var posX = platformPosX.Next(100, 800);
                    platform.transform.position.x = posX;
                    
                    continue;
                }


                if (monkey.IsBoxColliding(lava))
                     break;
                

                if (monkey.IsBoxColliding(platform))
                    break;


            }
            time.Update();
        }

        public override void Render() 
        {
            Engine.Clear();

            Engine.Draw("assets/Screens/mountain_texture.png", 0, 0, 1, 1, 0, 0, 0);

            foreach (var life in lifes)
            {
                life.Render();
            }
            
            monkey.Render();

            foreach (var platform in platforms)
            {
                platform.Render();
            }

            lava.Render();

            Engine.Show();
        }
    }
}
