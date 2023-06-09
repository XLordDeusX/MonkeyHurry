﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    public class Menu : Level
    {
        public override void Start() 
        {
            GameManager.Instance.soundPlayer = new SoundPlayer("assets/Sounds/menu.wav");
            GameManager.Instance.soundPlayer.PlayLooping();
        }
        public override void Update()
        {
            if (Engine.GetKey(Keys.N))
            {
                GameManager.Instance.ChangeScreen(GameManager.Instance.gameplay);
            }
        }
        public override void Render()
        {
            Engine.Clear();
            Engine.Draw("assets/Screens/Menu.png", 0, 0, 1.05f, 1.7f, 0, 38, 0);
            Engine.Show();
        }
    }
}
