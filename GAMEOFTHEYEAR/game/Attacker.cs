﻿using System;
using System.Collections.Generic;
using game.BattleArmyClasses;

// ReSharper disable InconsistentNaming

namespace game
{
    public class Attacker
    {
        public List<BattleUnitsStack> Attack((BattleUnitsStack, TypeOfArmy) currentBattleStack, BattleArmy attackedArmy, int i,ref string res)
        {
            
            
                        if (currentBattleStack.Item1.Effects.IsEffectApplied(TypeOfEffect.BeatAll))
                        {
                            List<BattleUnitsStack> attackedStacks = new List<BattleUnitsStack>();
                            for (int j = attackedArmy.AmountOfAliveStacks(); j > 0; j--)
                            {
                                attackedStacks.Add(attackedArmy.AliveStackAt(j));
                                res += Attack(currentBattleStack.Item1, attackedArmy.AliveStackAt(j));
                            }

                            return attackedStacks;
                        }
                        else
                        {
                            BattleUnitsStack attackedStack = attackedArmy.AliveStackAt(i);
                            res += Attack(currentBattleStack.Item1, attackedArmy.AliveStackAt(i));
                            return new List<BattleUnitsStack>() { attackedStack };

                        }

                    
                
            
        }
        public int Damage(BattleUnitsStack attackingBUS, BattleUnitsStack attackedBUS)
        {
            int IncreasedAttack = 0;
            int DecreasedAttack = 0;
            int DecreasedDefence = 0;
            int MultiplierOfDefence = 1;
            double IsDefend = 1;
            foreach (var effect in attackingBUS.Effects.AllEffects)
            {
                if (effect.Item1 == TypeOfEffect.DecreasedAttack)
                    DecreasedAttack = (int)Config.DECREASED_ATTACK;
                if (effect.Item1 == TypeOfEffect.IncreasedAttack)
                    IncreasedAttack = (int)Config.INCREASED_ATTACK;
                if (effect.Item1 == TypeOfEffect.AccurateShot)
                    MultiplierOfDefence = 0;
            }
            foreach (var effect in attackedBUS.Effects.AllEffects)
            {
                if (effect.Item1 == TypeOfEffect.DecreasedDefence)
                    DecreasedDefence = (int)Config.DECREASED_DEFENCE;
                if (effect.Item1 == TypeOfEffect.IsDefends)
                    IsDefend = Config.IS_DEFEND;
            }
            double damage1;
            double damage2;
            double attack = (int)attackingBUS.UnitType.Attack - DecreasedAttack + IncreasedAttack;
            double defence = ((int)attackedBUS.UnitType.Defence - DecreasedDefence) * IsDefend * MultiplierOfDefence;
            if (attack < 0)
                attack = 0;
            if (defence < 0)
                defence = 0;
            if (attack > defence)
            {
                damage1 = attackingBUS.Amount * (int)attackingBUS.UnitType.Damage.Item1 * (1 + 0.05 * (attack - defence));
                damage2 = attackingBUS.Amount * (int)attackingBUS.UnitType.Damage.Item2 * (1 + 0.05 * (attack - defence));
            }
            else
            {
                damage1 = attackingBUS.Amount * (int)attackingBUS.UnitType.Damage.Item1 / (1 + 0.05 * (defence - attack));
                damage2 = attackingBUS.Amount * (int)attackingBUS.UnitType.Damage.Item2 / (1 + 0.05 * (defence - attack));
            }
            if (attackingBUS.UnitType.Damage.Item1 == attackingBUS.UnitType.Damage.Item2)
                return (int)Math.Floor(damage2);
            Random rnd = new Random();
            return rnd.Next((int)Math.Ceiling(damage1), (int)Math.Floor(damage2));
        }
        public string Attack(BattleUnitsStack attacking, BattleUnitsStack attacked)
        {
            int damage = Damage(attacking, attacked);
            int dead = attacked.Amount;
            string res = "";
            if (damage < attacked.Hp)
            {
                attacked.Hp -= damage;
                dead -= attacked.Amount;
            }
            else
            {
                attacked.Hp = 0;//-= damage
            }

            res+=$"{attacking.UnitType.Name} make {damage} damage to {attacked.UnitType.Name}, {dead} dead\r\n";

            bool enemyDoesNotRespond = false;
            foreach (var effect in attacking.Effects.AllEffects)
            {
                if (effect.Item1 == TypeOfEffect.EnemyDoesNotRespond || effect.Item1 == TypeOfEffect.Archer)
                    enemyDoesNotRespond = true;
            }
            foreach (var effect in attacked.Effects.AllEffects)
            {
                if (effect.Item1 == TypeOfEffect.Archer)
                    enemyDoesNotRespond = true;
            }

            if (!attacked.HasRespondThisTurn && attacked.IsAlive && !enemyDoesNotRespond)
            {
                attacked.HasRespondThisTurn = true;
                foreach (var effect in attacked.Effects.AllEffects)
                {
                    if (effect.Item1 == TypeOfEffect.EndlessRebuff)
                        attacked.HasRespondThisTurn = false;
                }
                int damageOfRespond = Damage(attacked, attacking);
                dead = attacking.Amount;
                if (damageOfRespond < attacking.Hp)
                {
                    attacking.Hp -= damageOfRespond;
                    dead -= attacking.Amount;
                }
                else
                {
                    attacking.Hp = 0; //-= damageOfRespond
                }
                res+=$"{attacked.UnitType.Name} make {damageOfRespond} damage to {attacking.UnitType.Name} in return, {dead} dead\r\n";
                
            }
            return res;
        }
    }
}