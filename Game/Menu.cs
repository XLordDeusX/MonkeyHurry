using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Menu : Level
    {
        public override void Start() { }
        public override void Update()
        {
            if (Engine.GetKey(Keys.N))
            {
                GameManager.Instance.ChangeScreen(GameManager.Instance.gameplay);
            }

            if (Engine.GetKey(Keys.ESCAPE))
            {
                Engine.CloseWindow(); // NO ME CIERRA LA VENTANA PRESIONANDO ESC
            }
        }
        public override void Render()
        {
            Engine.Clear();
            Engine.Draw("assets/Screens/Menu.png", 0, 0, 1.05f, 1.7f, 0, 0, 0);
            Engine.Show();
        }
    }
}
