using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2_Scripting.Clases
{
    internal class Equip : Card
    {

        public enum TargetAttribute { AP, RP, ALL }
        public enum Affinity { Knight, Mage, Undead }
        private TargetAttribute targetAttribute;
        private Affinity affinity;

        uint effectPoints;
        

        public Equip(string name, lrarety rarety, Affinity affinity,uint effectPoints, TargetAttribute targetAttribute) : base(name, rarety, costPoint)
        {
            EfectPoints = effectPoints;
            TargetAttribute = targetAttribute;
            Affinity = affinity;
        }

        public uint EffectPoints { get => effectPoints; set => effectPoints = value; }
        public Affinity affinity { get => affinity; set => affinity = value; }
        public TargetAttribute targetAttribute { get => targetAttribute; set => targetAttribute = value; }

    }
}
