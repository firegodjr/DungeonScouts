using DungeonScouts.Map;
using DungeonScouts.Map.Tiles;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Drawing
{
    /// <summary>
    /// Manages the loading and optimization of resources such as textures and audio
    /// </summary>
    class ResourceManager
    {
        public Dictionary<string, Texture2D> TextureStore = new Dictionary<string, Texture2D>();
        private ContentManager content;

        private static string MISSING_TEX_PATH = "missing";

        public ResourceManager(ContentManager content)
        {
            this.content = content;
            TextureStore.Add(MISSING_TEX_PATH, content.Load<Texture2D>(MISSING_TEX_PATH));
        }

        public Texture2D GetTexture(string key)
        {
            if(TextureStore.ContainsKey(key))
            {
                return TextureStore[key];
            }
            else
            {
                Console.WriteLine($"TextureStore error: Cannot retrieve texture '{key}'");
                return TextureStore[MISSING_TEX_PATH];
            }
        }

        /// <summary>
        /// Load all required room textures into memory
        /// </summary>
        /// <param name="room"></param>
        /// <param name="content"></param>
        public void LoadRoomTextures(Room room)
        {
            string[] textureList = room.GetTextureList();
            foreach (string s in textureList)
            {
                if (!TextureStore.ContainsKey(s))
                {
                    try
                    {
                        TextureStore.Add(s, content.Load<Texture2D>(s));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Texture loading exception: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Unload all textures that this room uses
        /// </summary>
        /// <param name="room"></param>
        public void UnloadRoomTextures(Room room)
        {
            string[] textureList = room.GetTextureList();
            foreach (string s in textureList)
            {
                if (TextureStore.ContainsKey(s))
                {
                    TextureStore.Remove(s);
                }
            }
        }
    }

}
