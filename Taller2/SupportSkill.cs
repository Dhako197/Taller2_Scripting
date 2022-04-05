using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2
{
    internal class SupportSkill : Card
    {
        public enum l_EffectType {ReduceRP, ReduceAll, DestroyEquip, RestoreRP }

        private l_EffectType effectType;
        private int effectPoints;

        internal l_EffectType EffectType { get => effectType; set => effectType = value; }
        public int EffectPoints { get => effectPoints; set => effectPoints = value; }

        public SupportSkill(string name, lrarety rarety, uint costPoint, l_EffectType effectType, int effectPoints) : base(name, rarety, costPoint)
        {
            EffectType = effectType;
            EffectPoints = effectPoints;

        }


    }
}
