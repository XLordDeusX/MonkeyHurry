using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    public class GameManager
    {
        private static GameManager instance;

        public string menu = "Menu";
        public string gameplay = "Gameplay";
        public string victory = "Victory";
        public string defeat = "Defeat";
        public string currentScreen;

        public Level currentLevel;

        public SoundPlayer soundPlayer = new SoundPlayer();

        public Menu MenuScreen { get; private set; }
        public Gameplay GameplayScreen { get; private set; }
        public VictoryScreen VictoryScreen { get; private set; }
        public DefeatScreen DefeatScreen { get; private set; }


        public static GameManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public void Update()
        {
            currentLevel.Update();
        }

        public void Render()
        {
            Engine.Clear();
            currentLevel.Render();
            Engine.Show();
        }

        public void ChangeScreen(string newScreen)
        {
            currentScreen = newScreen;

            switch (currentScreen)
            {
                case "Menu":
                    if (MenuScreen == null)
                    {
                        MenuScreen = new Menu();
                    }
                    currentLevel = MenuScreen;
                    break;

                case "Gameplay":
                    if (GameplayScreen == null)
                    {
                        GameplayScreen = new Gameplay();
                    }
                    currentLevel = GameplayScreen;
                    break;

                case "Victory":
                    if (VictoryScreen == null)
                    {
                        VictoryScreen = new VictoryScreen();
                    }
                    currentLevel = VictoryScreen;
                    break;

                case "Defeat":
                    if (DefeatScreen == null)
                    {
                        DefeatScreen = new DefeatScreen();
                    }
                    currentLevel = DefeatScreen;
                    break;

                default:
                    break;
            }

            currentLevel.Start();
        }

        public void StartScreen()
        {
            ChangeScreen(currentScreen = menu);
        }
    }
}
