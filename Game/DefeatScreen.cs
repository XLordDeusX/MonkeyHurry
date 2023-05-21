using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    public class DefeatScreen : Level
    {
        public override void Start() 
        {
            GameManager.Instance.soundPlayer = new SoundPlayer("assets/Sounds/lose.wav");
            GameManager.Instance.soundPlayer.Play();
        }
        public override void Update()
        {
            if (Engine.GetKey(Keys.ESCAPE))
            {
                GameManager.Instance.ChangeScreen(GameManager.Instance.menu);
            }
        }
        public override void Render()
        {
            Engine.Clear();
            Engine.Draw("assets/Screens/Game_Over.png", 0, 0, 1f, 1.2f, 0, 0, -100);
            Engine.Show();
        }
    }
}
