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

        private Menu menuScreen = new Menu();
        private Gameplay gameplayScreen = new Gameplay();
        private VictoryScreen victoryScreen = new VictoryScreen();
        private DefeatScreen defeatScreen = new DefeatScreen();

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
            switch (currentScreen)
            {
                case "Menu":
                    if (MenuScreen == null)
                    {
                        MenuScreen = new Menu();
                        menuScreen.Start();
                    }
                    menuScreen.Update();
                    GameplayScreen = null;
                    VictoryScreen = null;
                    DefeatScreen = null;
                    break;

                case "Gameplay":
                    if(GameplayScreen == null)
                    {
                        GameplayScreen = new Gameplay();
                        GameplayScreen.Start();
                    }
                    gameplayScreen.Update();
                    MenuScreen = null;
                    break;

                case "Victory":
                    if (VictoryScreen == null)
                    {
                        VictoryScreen = new VictoryScreen();
                        victoryScreen.Start();
                    }
                    victoryScreen.Update();
                    break;

                case "Defeat":
                    if (DefeatScreen == null)
                    {
                        DefeatScreen = new DefeatScreen();
                        defeatScreen.Start();
                    }
                    defeatScreen.Update();
                    break;

                default:
                    break;
            }
        }

        public void Render()
        {
            Engine.Clear();
            switch (currentScreen)
            {
                case "Menu":
                    menuScreen.Render();
                    break;

                case "Gameplay":
                    gameplayScreen.Render();
                    break;

                case "Victory":
                    victoryScreen.Render();
                    break;

                case "Defeat":
                    defeatScreen.Render();
                    break;

                default:
                    break;
            }
            Engine.Show();
        }

        public void ChangeScreen(string newScreen)
        {
            currentScreen = newScreen;
        }

        public void StartScreen()
        {
            ChangeScreen(currentScreen = menu);
        }
    }
}
