using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Map.Tiles
{
    interface ITile
    {
        string Name { get; }
        string Description { get; }
        string TexturePath { get; }
    }
}
