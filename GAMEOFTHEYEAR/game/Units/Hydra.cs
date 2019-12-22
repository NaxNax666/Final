using game.BattleArmyClasses;
using game.MarchingArmy;

namespace game.Units
{
    public class Hydra : Unit
    {
        public Hydra() : base("Гидра", 80, 15, 12, damage: (7, 14), 7,"9.png")
        {
            congenitalEffects.Add(TypeOfEffect.BeatAll);
            congenitalEffects.Add(TypeOfEffect.EnemyDoesNotRespond);
        }
    }
}
