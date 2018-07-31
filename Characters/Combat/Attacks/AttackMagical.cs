using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Characters.Combat.Attacks
{
    class AttackMagical : IAttack
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float HitPercent { get; set; }

        public AttackMagical(string name, string description, float hitPercent)
        {
            this.Name = name;
            this.Description = description;
            this.HitPercent = hitPercent;
        }

        public virtual AttackResult performAttack(Actor attacker, Actor opponent, Weapon weapon)
        {
            return new AttackResult();
        }
    }
}
