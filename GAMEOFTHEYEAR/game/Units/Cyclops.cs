using game.BattleArmyClasses;
using game.MarchingArmy;

namespace game.Units
{
    public class Cyclops : Unit
    {
        public Cyclops() : base("Циклоп", 85, 20, 15, damage: (18, 26), 10,"5.png")
        {
            this.accessibleMagic.Add(TypeOfMagic.Attenuation);
        }
    }
}
