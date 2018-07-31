using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Characters
{
    interface IItem
    {
        string Name { get; }
        string Description { get; }
        Rarity Rarity { get; }
    }

    public enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        LEGENDARY,
        EXOTIC
    }
}
