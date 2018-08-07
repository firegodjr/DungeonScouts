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

        public Transform2D(int x = 0, int y = 0, float rotation = 0, int width = 1, int height = 1)
        {
            PosX = x;
            PosY = y;
            Rotation = rotation;
            Width = width;
            Height = height;
        }
    }
}
