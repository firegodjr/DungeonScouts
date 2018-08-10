using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Drawing
{
    class Transform2D
    {
        public int PosX;
        public int PosY;
        public float Rotation;
        public int Width;
        public int Height;
        public float Scale;

        public Transform2D(int x = 0, int y = 0, float rotation = 0, int width = 0, int height = 0, float scale = 1.0f)
        {
            PosX = x;
            PosY = y;
            Rotation = rotation;
            Width = width;
            Height = height;
            Scale = scale;
        }

        /// <summary>
        /// Offsets a single Transform2D based on the camera's transform.
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public Transform2D transformTransform2D(Transform2D transform2D)
        {
            Transform2D tempTransform = (Transform2D)transform2D.MemberwiseClone();
            tempTransform.PosX += PosX;
            tempTransform.PosY += PosY;
            tempTransform.Rotation += Rotation;
            tempTransform.Width += Width;
            tempTransform.Height += Height;
            tempTransform.Scale += Scale;

            return tempTransform;
        }

        public static Transform2D operator +(Transform2D a, Transform2D b)
        {
            return a.transformTransform2D(b);
        }

        public static Transform2D operator -(Transform2D a, Transform2D b)
        {
            return a.transformTransform2D(new Transform2D(-b.PosX, -b.PosY, -b.Rotation, -b.Width, -b.Height, -b.Scale));
        }
    }
}
