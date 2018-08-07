using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Map.Tiles.TileTypes
{
    class BlankTile : ITile
    {
        public string Name => "Empty";
        public string Description => "An empty space, and nothing more.";
        public string TexturePath => "Tiles/tileBlank";
    }
}
