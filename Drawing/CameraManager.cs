using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Drawing
{
    /// <summary>
    /// A singleton that manages the offset for all drawn sprites, 
    /// simulating a dynamic camera
    /// </summary>
    class CameraManager
    {
        private static CameraManager singleton = null;
        public static int ViewWidth = 1600;
        public static int ViewHeight = 900;

        public Transform2D Transform;
        public static CameraManager Camera
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new CameraManager();
                }

                return singleton;
            }
        }

        private CameraManager()
        {
            Transform = new Transform2D();
        }

        /// <summary>
        /// Offsets a single Transform2D based on the camera's transform.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Transform2D applyCameraOffset(Transform2D t)
        {
            Transform2D result = t - Transform;
            result.PosX = ViewWidth / 2 + (int)(result.PosX * Transform.Scale);
            result.PosY = ViewHeight / 2 + (int)(result.PosY * Transform.Scale);
            result.Width = (int)(result.Width * Transform.Scale);
            result.Height = (int)(result.Height * Transform.Scale);
            return result;
        }
    }
}
