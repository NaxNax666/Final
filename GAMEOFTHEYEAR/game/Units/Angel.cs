using game.MarchingArmy;

namespace game.Units
{
    public class Angel : Unit
    {
        public Angel() : base("Ангел", 180, 27, 27, damage: (45, 45), 11,"11.png")        {
            this.accessibleMagic.Add(TypeOfMagic.Resurrection);
            this.accessibleMagic.Add(TypeOfMagic.PunishingStrike);
        }
        public override string Roar()
        {
            return "MAAAAAAAAa";
        }
    }
}