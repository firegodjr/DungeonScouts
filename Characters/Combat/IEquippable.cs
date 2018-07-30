using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Characters.Combat
{
    interface IEquippable
    {
        EquipmentSlot equipSlot { get; }
    }
}
