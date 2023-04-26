using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //This part contains all the items that character executed and their values.
    public class Transform
    {
        private float posX ;
        private float posY;
        private float rot = 0f;
        private float scaleX = 2f;
        private float scaleY = 2f;
        private float offsetX = 0f;
        private float offsetY = 0f;

        public float PosX => posX;
        public float PosY => posY;
        public float Rot => rot;
        public float ScaleX => scaleX;
        public float ScaleY => scaleY;
        public float OffsetX => offsetX;
        public float OffsetY => offsetY;



        public Transform(float p_posX, float p_posY)
        {
            posX = p_posX;
            posY = p_posY;
        }

        public void Move (float x, float y)
        {
            posX += x;
            posY += y;
        }
    }

    //The script variables were also passed structure
    /*public class TransformStructures
    {
        private float posX;
        private float posY;
        private float rot = 0f;
        private float scaleX = 1.5f;
        private float scaleY = 1.5f;
        private float offsetX = 0f;
        private float offsetY = 0f;

        public float PosX => posX;
        public float PosY => posY;
        public float Rot => rot;
        public float ScaleX => scaleX;
        public float ScaleY => scaleY;
        public float OffsetX => offsetX;
        public float OffsetY => offsetY;

        public TransformStructures(float p_posX, float p_posY)
        {
            posX = p_posX;
            posY = p_posY;
        }

        public void StructureMove(float x, float y)
        {
            posX += x;
            posY += y;
        }
    }*/
}
