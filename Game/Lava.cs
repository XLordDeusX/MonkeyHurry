﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Lava : GameObject, IMovement
    {
        private Animation lava;
        private float speedY = 165;
        public float timerLava = -5;
        private float realTimer = -5;


        public Lava(string p_name, Transform p_transform) : base(p_name,p_transform)
        {
            lava = CreateAnimation("Lava", "assets/Animations/Lava/lava_", 8, 0.06f, true);
            currentAnimation = lava;
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
            LavaMovement();
            currentAnimation.Update();
        }

        public bool IsBoxColliding(Platforms p_obj)
        {
            float distancePlatformX = Math.Abs(transform.position.x - p_obj.Transform.position.x);
            float distancePlatformY = Math.Abs(transform.position.y - p_obj.Transform.position.y);

            float sumHalfWidthsPlat = RealWidth / 2 + p_obj.RealWidth / 2;
            float sumHalfHeightsPlat = RealHeight / 2 + p_obj.RealHeight / 2;

            if (distancePlatformX <= sumHalfWidthsPlat && distancePlatformY <= sumHalfHeightsPlat)
            {
                //p_obj.OnDie += Gameplay.platformsPool.AddToPool;
                
                p_obj.draw = false;
                return true;
            }

            /*var platform = Gameplay.platformsPool.GetObjectsFromPool();
            if(platform == default)
            {
                platform = new Platforms("platform", new Transform(new Vector2(700, 100), 0, new Vector2(1, 1)));
            }
            else
            {
                platform.Reset("platform", new Transform(new Vector2(700, 100), 0, new Vector2(1, 1)));
            }*/

            p_obj.draw = true;
            return false;
        }
        public void LavaMovement()
        {
            timerLava += Time.deltaTime;

            if (timerLava >= 2.5f && timerLava <= 5.8f)
            {
                Move(new Vector2(0, -speedY));
            }

            if (timerLava >= 6.2f && timerLava <= 9.5f)
            {
                Move(new Vector2(0, speedY));
            }

            if (timerLava >= 10.5f)
            {
                timerLava = -1;
            }
        }

        public void Move(Vector2 pos)
        {
            transform.position.x += pos.x * Time.deltaTime;
            transform.position.y += pos.y * Time.deltaTime;
        }
    }
}
