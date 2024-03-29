﻿using System.Collections.Generic;
using game.BattleArmyClasses;

namespace game.MarchingArmy
{
    public class Unit
    {
        public string Name { get; }
        public uint HitPoints { get; }
        public uint Attack { get; }
        public uint Defence { get; }
        public (uint, uint) Damage { get; }
        public double Initiative { get; }
        public string Pic { get; }

        protected List<TypeOfMagic> accessibleMagic;

        public List<TypeOfMagic> AccessibleMagic
        {
            get
            {
                var newMagicList = new List<TypeOfMagic>();
                accessibleMagic.ForEach((magic) => newMagicList.Add(magic));
                return newMagicList;
            }
        }

        protected List<TypeOfEffect> congenitalEffects;

        public List<TypeOfEffect> CongenitalEffects
        {
            get
            {
                var newEffectList = new List<TypeOfEffect>();
                congenitalEffects.ForEach((effect) => newEffectList.Add(effect));
                return newEffectList;
            }
        }

        public Unit(string name, uint hitPoints, uint attack, uint defence, (uint, uint) damage,
            double initiative,string pic)
        {
            this.Name = name;
            this.HitPoints = hitPoints;
            this.Attack = attack;
            this.Defence = defence;
            this.Damage = damage;
            this.Initiative = initiative;
            this.Pic = pic;
            accessibleMagic = new List<TypeOfMagic>();
            congenitalEffects = new List<TypeOfEffect>();
        }
        public virtual string Roar()
        {
            return "";
        }
        public Unit Clone()
        {
            Unit currentUnit = new Unit(this.Name, this.HitPoints, this.Attack, this.Defence, this.Damage, this.Initiative,this.Pic);
            foreach (var magic in AccessibleMagic)
            {
                currentUnit.accessibleMagic.Add(magic);
            }
            foreach (var effect in CongenitalEffects)
            {
                currentUnit.congenitalEffects.Add(effect);
            }
            return currentUnit;
        }
    }
}

