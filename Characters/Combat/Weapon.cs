using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Characters.Combat
{
    class Weapon : IItem, IEquippable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Rarity Rarity { get; set; }
        public string Damage { get; }

        public EquipmentSlot equipSlot => EquipmentSlot.WEAPON;

        public Weapon()
        {
            
        }
    }
}
