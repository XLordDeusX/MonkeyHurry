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
        public static GameManager GetInstance()
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
}
