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
    /// Manages all loaded resources such as textures, audio, and sprites
    /// </summary>
    class ResourceManager
    {
        public Dictionary<string, Texture2D> TextureStore = new Dictionary<string, Texture2D>();
        private List<SpriteGroup> spriteGroups = new List<SpriteGroup>();
        private ContentManager content;

        private string MISSING_TEX_PATH = "missing";
        private int TILE_WIDTH = 32;
        private int TILE_HEIGHT = 16;

        public ResourceManager(ContentManager content)
        {
            this.content = content;
            TextureStore.Add(MISSING_TEX_PATH, content.Load<Texture2D>(MISSING_TEX_PATH));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(SpriteGroup group in spriteGroups)
            {
                foreach(Sprite s in group.Sprites)
                {
                    s.Draw(spriteBatch);
                }
            }
        }

        public Texture2D GetTexture(string key)
        {
            if(TextureStore.ContainsKey(key))
            {
                return TextureStore[key];
            }
            else
            {
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

        /// <summary>
        /// Loads room sprites, assuming all needed textures are in the TextureStore
        /// </summary>
        /// <param name="room"></param>
        public void CreateRoomSprites(Room room)
        {
            SpriteGroup newSpriteGroup = new SpriteGroup();
            for(int x = 0; x < room.Tiles.Length; ++x)
            {
                for(int y = 0; y < room.Tiles[x].Length; ++y)
                {
                    int xPos = (-x + y) * TILE_WIDTH / 2;
                    int yPos = (x + y) * TILE_HEIGHT / 2;
                    newSpriteGroup.Sprites.Add(new Sprite(GetTexture(room.Tiles[x][y].TexturePath), xPos, yPos));
                }
            }
            spriteGroups.Add(newSpriteGroup);
        }

        private class SpriteGroup
        {
            public enum GroupType
            {
                WORLD,
                ENTITY
            }

            public GroupType type;
            public List<Sprite> Sprites = new List<Sprite>();
        }
    }

}
