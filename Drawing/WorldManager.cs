using DungeonScouts.Map;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Drawing
{
    /// <summary>
    /// Object that stores, categorizes, and draws all onscreen sprites
    /// </summary>
    class WorldManager
    {
        private List<SpriteGroup> spriteGroups = new List<SpriteGroup>();
        private int TILE_WIDTH = 32;
        private int TILE_HEIGHT = 16;

        private CameraManager camera;

        public WorldManager(CameraManager camera)
        {
            this.camera = camera;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (SpriteGroup group in spriteGroups)
            {
                foreach (Sprite s in group.Sprites)
                {
                    s.Draw(spriteBatch, camera);
                }
            }
        }

        /// <summary>
        /// Loads room sprites, assuming all needed textures are in the TextureStore
        /// </summary>
        /// <param name="room"></param>
        public void CreateRoomSprites(Room room, ResourceManager resourceManager)
        {
            SpriteGroup newSpriteGroup = new SpriteGroup(SpriteGroup.GroupType.WORLD);
            for (int x = 0; x < room.Tiles.Length; ++x)
            {
                for (int y = 0; y < room.Tiles[x].Length; ++y)
                {
                    int xPos = (-x + y) * TILE_WIDTH / 2;
                    int yPos = (x + y) * TILE_HEIGHT / 2;
                    newSpriteGroup.Sprites.Add(new Sprite(resourceManager.GetTexture(room.Tiles[x][y].TexturePath), xPos, yPos));
                }
            }
            spriteGroups.Add(newSpriteGroup);
        }

        /// <summary>
        /// Loads room actors, assuming all needed textures are in the TextureStore
        /// </summary>
        /// <param name="room"></param>
        public void CreateRoomActors(Room room, ResourceManager resourceManager)
        {
            SpriteGroup newSpriteGroup = new SpriteGroup(SpriteGroup.GroupType.ENTITY); //TODO: reposition actors every frame
            for (int i = 0; i < room.RoomActors.Count; ++i)
            {
                Texture2D actorTexture = room.RoomActors[i].GetActorTexture(resourceManager);
                int x = room.ActorTilePositions[i].x;
                int y = room.ActorTilePositions[i].y;
                int xPos = (-x + y) * TILE_WIDTH / 2;
                int yPos = (x + y) * TILE_HEIGHT / 2 - actorTexture.Height + TILE_HEIGHT; // Offset actor origin to be at the bottom of the tile sprite at the same position
                newSpriteGroup.Sprites.Add(new Sprite(actorTexture, xPos, yPos));
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

            public SpriteGroup(GroupType type)
            {
                this.type = type;
            }
        }
    }
}
