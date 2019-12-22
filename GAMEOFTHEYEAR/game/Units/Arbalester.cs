using game.BattleArmyClasses;
using game.MarchingArmy;

namespace game.Units
{
    public class Arbalester : Unit
    {
        public Arbalester() : base("Арбалетчик", 10, 4, 4, (2, 8), 8,"10.png")
        {
            congenitalEffects.Add(TypeOfEffect.Archer);
            congenitalEffects.Add(TypeOfEffect.AccurateShot);
        }
    }
}