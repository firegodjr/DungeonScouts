using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Characters.Combat
{
    class Spell : Attack
    {
        public enum SpellEffect
        {
            HEAL,
            DAMAGE,
            BURN,
            FREEZE,
            PARALYZE,
            HYPNOTIZE
        }

        SpellEffect effect;

        public Spell(string name, int maxDamage, int minDamage, float hitChance, SpellEffect effect)
            : base(name, maxDamage, minDamage, hitChance)
        {
            this.effect = effect;
        }

        public override void performAttack(Character attacker, Character opponent, Weapon weapon)
        {
            if(effect != SpellEffect.HEAL)
            {
                base.performAttack(attacker, opponent, weapon);
            }
        }
    }
}
