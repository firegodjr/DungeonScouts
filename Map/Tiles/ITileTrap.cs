﻿using DungeonScouts.Characters.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonScouts.Map.Tiles
{
    interface ITileTrap
    {
        IAttack OnStepAttack { get; set; }
    }
}
