using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Characters.Combat
{
    class Attack
    {
        string name;
        int maxDamage;
        int minDamage;
        float hitChance;

        public Attack(string name, int maxDamage, int minDamage, float hitChance)
        {
            this.name = name;
            this.maxDamage = maxDamage;
            this.minDamage = minDamage;
            this.hitChance = hitChance;
        }

        public virtual void performAttack(Character attacker, Character opponent, Weapon weapon)
        {
            //TODO
        }

        public struct AttackResult
        {
            int damageDealt;
            bool opponentDied;
        }
    }
}
