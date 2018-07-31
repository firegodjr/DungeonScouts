using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Characters.Combat
{
    class AttackPhysical : IAttack
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float HitPercent { get; set; }
        int maxDamage;
        int minDamage;

        public AttackPhysical(string name, string description, int maxDamage, int minDamage, float hitPercent)
        {
            this.Name = name;
            this.Description = description;
            this.maxDamage = maxDamage;
            this.minDamage = minDamage;
            this.HitPercent = hitPercent;
        }

        public virtual AttackResult performAttack(Actor attacker, Actor opponent, Weapon weapon)
        {
            return new AttackResult();
        }
    }
}
