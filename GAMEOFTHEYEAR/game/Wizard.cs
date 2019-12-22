using System;
using System.Collections.Generic;
using game.BattleArmyClasses;

namespace game
{
    public class Wizard
    {
        public string Wiz((BattleUnitsStack, TypeOfArmy) currentBattleStack, BattleArmy FirstBattleArmy, BattleArmy SecondBattleArmy, List<(BattleUnitsStack, TypeOfArmy)> Scale,int i,int j, BattleArmy toWhatArmyUseMagic,TypeOfMagic chosenMagic)
        {
                           
             currentBattleStack.Item1.BunToWiz(chosenMagic);

            {

                if (chosenMagic == TypeOfMagic.Resurrection)
                {
                    BattleUnitsStack toWhatStackUseMagic = toWhatArmyUseMagic.StacksList[j - 1];
                    return Resurrection(toWhatStackUseMagic, currentBattleStack.Item1)+"\r\n";

                }
                else
                {

                    BattleUnitsStack toWhatStackUseMagic = toWhatArmyUseMagic.AliveStackAt(j);
                    switch (chosenMagic)
                    {
                        case TypeOfMagic.Acceleration:
                            Acceleration(toWhatStackUseMagic);
                            break;
                        case TypeOfMagic.Attenuation:
                            Attenuation(toWhatStackUseMagic);
                            break;
                        case TypeOfMagic.PunishingStrike:
                            PunishingStrike(toWhatStackUseMagic);
                            break;
                        case TypeOfMagic.Curse:
                            Curse(toWhatStackUseMagic);
                            break;
                    }

                }
                


                return "";
            }
                    
        }
        public void PunishingStrike(BattleUnitsStack currentBattleUnitsStack)
        {
            currentBattleUnitsStack.Effects.Add((TypeOfEffect.IncreasedAttack, 3));
        }
        public void Curse(BattleUnitsStack currentBattleUnitsStack)
        {
            currentBattleUnitsStack.Effects.Add((TypeOfEffect.DecreasedAttack, 3));
        }
        public void Attenuation(BattleUnitsStack currentBattleUnitsStack)
        {
            currentBattleUnitsStack.Effects.Add((TypeOfEffect.DecreasedDefence, 5));
        }
        public void Acceleration(BattleUnitsStack currentBattleUnitsStack)
        {
            currentBattleUnitsStack.Effects.Add((TypeOfEffect.IncreasedInitiative, 3));
        }
        public string Resurrection(BattleUnitsStack currentBattleUnitsStack, BattleUnitsStack whoHeal)
        {
            int healing = whoHeal.Amount;
            switch (whoHeal.UnitType.Name)
            {
                case "Angel":
                    healing *= Config.ANGEL_HEALING;
                    break;
                case "Lich":
                    healing *= Config.LICH_HEALING;
                    break;
                default:
                    healing *= Config.DEFAULT_HEALING;
                    break;
            }

            int amountBeforeHealing;
            int startHp = currentBattleUnitsStack.StartAmount * (int)currentBattleUnitsStack.UnitType.HitPoints;
            if (currentBattleUnitsStack.Hp < 0)
            {
                currentBattleUnitsStack.Hp = 0;
                amountBeforeHealing = 0;
            }
            else
            {
                amountBeforeHealing = currentBattleUnitsStack.Amount;
            }

            if (healing + currentBattleUnitsStack.Hp >= startHp)
                currentBattleUnitsStack.Hp = startHp;
            else
                currentBattleUnitsStack.Hp += healing;
            return $"{currentBattleUnitsStack.Amount - amountBeforeHealing} {currentBattleUnitsStack.UnitType.Name} has been returned";
        }
    }

    public enum TypeOfMagic
    {
        PunishingStrike,
        Curse,//проклятие
        Attenuation,//ослабление
        Acceleration,
        Resurrection//воскрешение
    }
}