using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Drawing
{
    class Sprite
    {
        Texture2D texture;
        string resourceName;
        Transform2D transform;
        bool isPixelArt = true;

        public Sprite(Texture2D texture, int xPos = 0, int yPos = 0, int width = -1, int height = -1)
        {
            this.texture = texture;
            this.transform = new Transform2D(xPos, yPos, 0, width != -1 ? width : texture.Width, height != -1 ? height : texture.Height);
        }

        /// <summary>
        /// Attempts loading this sprite using the given resource name.
        /// If null, uses this sprite's resourceName property.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns>Load success</returns>
        public bool Load(ContentManager content, string resourceName = null)
        {
            resourceName = resourceName ?? this.resourceName;
            try
            {
                texture = content.Load<Texture2D>(resourceName);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Draws the sprite using the given SpriteBatch and camera
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch, CameraManager camera)
        {
            Transform2D offset = camera.applyCameraOffset(transform);
            spriteBatch.Draw(texture, new Rectangle(offset.PosX, offset.PosY, offset.Width, offset.Height), Color.White);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(transform.PosX, transform.PosY, transform.Width, transform.Height), Color.White);
        }
    }
}
