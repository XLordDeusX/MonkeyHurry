using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameObject
    {
        public string name;
        public Transform transform;
        protected Animation currentAnimation;

        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        public GameObject(string p_name, Transform p_transform)
        {
            name = p_name;
            transform = p_transform;
        }
    }
}
