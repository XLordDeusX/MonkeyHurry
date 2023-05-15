using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Menu menuScreen = new Menu();
        public Gameplay gameplayScreen = new Gameplay();
        public VictoryScreen victoryScreen = new VictoryScreen();
        public DefeatScreen defeatScreen = new DefeatScreen();

        public Gameplay GameplayScreen { get; private set; }
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
                    menuScreen.Update();
                    GameplayScreen = null;
                    break;

                case "Gameplay":
                    if(GameplayScreen == null)
                    {
                        GameplayScreen = new Gameplay();
                        GameplayScreen.Start();
                    }
                    gameplayScreen.Update();
                    break;

                case "Victory":
                    victoryScreen.Update();
                    break;

                case "Defeat":
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
