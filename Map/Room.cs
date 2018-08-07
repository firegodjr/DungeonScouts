using DungeonScouts.Characters;
using DungeonScouts.Map.Tiles;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Map
{
    class Room
    {
        public ITile[][] Tiles;

        /// <summary>
        /// All the actors that currently reside in this room
        /// </summary>
        List<Actor> roomActors;
        /// <summary>
        /// List parallel to roomActors that contains each actor's tile position
        /// </summary>
        List<TilePosition> actorTilePositions;

        public Room(ITile[][] tiles)
        {
            this.Tiles = tiles;
        }

        /// <summary>
        /// Add an actor to the room at the given position, and associate the actor with this room
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="position"></param>
        public void AddActor(Actor actor, TilePosition position)
        {
            actor.CurrentRoom = this;
            roomActors.Add(actor);
            actorTilePositions.Add(position);
        }

        /// <summary>
        /// Remove an actor from the room
        /// </summary>
        /// <param name="actor"></param>
        public void RemoveActor(Actor actor)
        {
            actorTilePositions.Remove(actorTilePositions[roomActors.IndexOf(actor)]);
            roomActors.Remove(actor);
        }

        /// <summary>
        /// Remove any actors that are currently associated with different rooms, or are dead
        /// </summary>
        public void CleanActors()
        {
            foreach(Actor a in roomActors)
            {
                if(a.CurrentRoom != this || !a.Living)
                {
                    RemoveActor(a);
                }
            }
        }

        /// <summary>
        /// Get a list of all textures that need to be available to draw this room
        /// </summary>
        public string[] GetTextureList()
        {
            List<string> textureList = new List<string>();

            foreach(ITile[] tileRow in Tiles)
            {
                foreach(ITile tile in tileRow)
                {
                    if(!textureList.Contains(tile.TexturePath))
                    {
                        textureList.Add(tile.TexturePath);
                    }
                }
            }

            return textureList.ToArray();
        }
    }

    /// <summary>
    /// The XY coordinates of an actor, corresponding to the room's tile layout
    /// </summary>
    struct TilePosition
    {
        int x;
        int y;
        public TilePosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
