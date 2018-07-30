using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Characters.Combat
{
    class Weapon : Item, IEquippable
    {
        public EquipmentSlot equipSlot => EquipmentSlot.WEAPON;
    }
}
