using DungeonScouts.Characters.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Characters
{
    class Character
    {
        bool living = true;
        string name;
        string description;
        Race race;
        Dictionary<EquipmentSlot, IEquippable> equipment = new Dictionary<EquipmentSlot, IEquippable>();

        int health;
        int maxHealth;
        List<Attack> attacks = new List<Attack>();
        List<Spell> spells = new List<Spell>();
        List<Item> items = new List<Item>();

        public Character(Race race, string name, string description, int maxHealth, Attack[] attacks, Spell[] spells, Item[] items)
        {
            this.name = name;
            this.maxHealth = maxHealth;
            this.attacks.AddRange(attacks);
            this.spells.AddRange(spells);
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
