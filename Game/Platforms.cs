﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Platforms : GameObject, IRenderizable
    {
        private Animation platform;
        private float speedX = 0;
        private float speedY = 0;

        public Transform Transform
        {
            get
            {
                return transform;
            }

            set
            {
                transform = value;
            }
        }
        
        public Platforms(string p_name, Transform p_transform) : base(p_name,p_transform)
        {
            platform = CreateAnimation("Platform", "assets/Animations/Platforms/platform_", 2, 0, false);
            currentAnimation = platform;
            RenderizablesManager.Instance.AddObjet(this);
        }

        private Animation CreateAnimation(string p_animationID, string p_path, int p_texturesAmount, float p_animationSpeed, bool p_isLoop)
        {
            List<Texture> animationFrames = new List<Texture>();

            for (int i = 1; i < p_texturesAmount; i++)
            {
                animationFrames.Add(Engine.GetTexture($"{p_path}{i}.png"));
            }

            Animation animation = new Animation(p_animationID, p_animationSpeed, animationFrames, p_isLoop);

            return animation;
        }
        
        public void Update()
        {
            Move(new Vector2(speedX, speedY));
            currentAnimation.Update();
        }

        public void Move(Vector2 pos)
        {
            transform.position.x += pos.x * Time.deltaTime;
            transform.position.y += pos.y * Time.deltaTime;
        }
    }
}