using DungeonScouts.Characters.Combat;
using DungeonScouts.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Characters
{
    /// <summary>
    /// A living person, or creature, that can stand on room tiles, equip items, and attack other actors
    /// </summary>
    class Actor
    {
        public bool Living { get => living; }
        bool living = true;
        string name;
        string description;
        Race race;
        Dictionary<EquipmentSlot, IEquippable> equipment = new Dictionary<EquipmentSlot, IEquippable>();

        int health;
        int maxHealth;
        List<IAttack> attacks = new List<IAttack>();
        List<IItem> items = new List<IItem>();

        /// <summary>
        /// The room that this actor should currently be in
        /// </summary>
        public Room CurrentRoom = null;

        public Actor(Race race, string name, string description, int maxHealth, IAttack[] attacks, IItem[] items)
        {
            this.name = name;
            this.maxHealth = maxHealth;
            this.attacks.AddRange(attacks);
            this.items.AddRange(items);
        }

        public void Equip(IEquippable item)
        {
            equipment.Add(item.equipSlot, item);
        }
    }

    public enum Race
    {
        HUMAN
    }

    public enum EquipmentSlot
    {
        WEAPON,
        HEAD,
        CHEST,
        ARMS,
        HANDS,
        LEGS,
        FEET,
        RING,
        NECK
    }
}
