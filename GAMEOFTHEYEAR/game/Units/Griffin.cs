﻿using game.BattleArmyClasses;
using game.MarchingArmy;

namespace game.Units
{
    public class Griffin : Unit
    {
        public Griffin() : base("Гриффон", 30, 7, 5, damage: (7, 12), 15,"1.png")
        {
            congenitalEffects.Add(TypeOfEffect.EndlessRebuff);
        }
    }
}