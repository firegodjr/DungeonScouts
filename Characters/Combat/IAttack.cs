using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Characters.Combat
{
    interface IAttack
    {
        string Name { get; }
        string Description { get; }
        float HitPercent { get; }
        AttackResult performAttack(Actor attacker, Actor target, Weapon weapon);
    }

    public struct AttackResult
    {
        int damageDealt;
        bool opponentDied;

        public AttackResult(int damageDealt, bool opponentDied)
        {
            this.damageDealt = damageDealt;
            this.opponentDied = opponentDied;
        }
    }
}
