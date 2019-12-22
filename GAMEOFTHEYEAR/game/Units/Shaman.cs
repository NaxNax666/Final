using game.MarchingArmy;

namespace game.Units
{
    public class Shaman : Unit
    {
        public Shaman() : base("Шаман", 40, 12, 10, damage: (7, 12), 10.5,"2.png")
        {
            this.accessibleMagic.Add(TypeOfMagic.Curse);
            this.accessibleMagic.Add(TypeOfMagic.Attenuation);
            this.accessibleMagic.Add(TypeOfMagic.PunishingStrike);
            this.accessibleMagic.Add(TypeOfMagic.Acceleration);
        }
    }
}