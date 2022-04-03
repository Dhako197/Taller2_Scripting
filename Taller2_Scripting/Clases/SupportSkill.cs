using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2_Scripting.Clases
{
    internal class SupportSkill : Card
    {
        public enum EffectType { ReduceAP, ReduceRP, ReduceAll, DestroyEquip, RestoreRP }
        public EffectType effectType;

        int effectPoints;

        public SuportSkill(string name, lrarety rarety, EffectType effectType, int effectPoints) : base(name, rarety, costPoint)
        {
            EfectPoints = effectPoints;
            EffectType = effectType;
            
        }

        public uint EffectPoints { get => effectPoints; set => effectPoints = value; }
        public EffectType effectType { get => effectType; set => effectType = value; }
        
    }
}
