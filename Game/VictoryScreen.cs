using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class VictoryScreen : Level
    {
        public override void Start() {}
        public override void Update()
        {
            if (Engine.GetKey(Keys.ESCAPE))
            {
                if (GameManager.Instance.currentScreen == GameManager.Instance.victory)
                {
                    GameManager.Instance.ChangeScreen(GameManager.Instance.menu);
                }
            }
        }
        public override void Render()
        {
            Engine.Clear();
            Engine.Draw("assets/Screens/You_Won.png", 0, 0, 1.2f, 1.55f, 0, 0, 0);
            Engine.Show();
        }
    }
}
