using game.MarchingArmy;

namespace game.Units
{
    public class Devil : Unit
    {
        public Devil() : base("Демон", 166, 27, 25, damage: (36, 66), 11,"3.png")
        {
            this.accessibleMagic.Add(TypeOfMagic.Attenuation);
            this.accessibleMagic.Add(TypeOfMagic.Curse);
            this.accessibleMagic.Add(TypeOfMagic.PunishingStrike);
        }
        public override string Roar()
        {
            return "TRATATATTAA";
        }
    }
}
