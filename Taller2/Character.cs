using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2
{
    class Character : Card
    {
        public enum laffinitys { Knight, Mage, Undead }


        private int attackPoints = 0;
        private int resistPoints = 0;
        private List<Equip> lequips;
        private laffinitys affinity;


        public Character(string name, lrarety rarety, uint costPoint, int attackPoints, int resistPoints, List<Equip> lequips, laffinitys affinity) : base(name, rarety, costPoint)
        {
            AttackPoints = attackPoints;
            ResistPoints = resistPoints;
            Lequips = lequips;
            Affinity = affinity;
        }

        public int AttackPoints { get => attackPoints; set => attackPoints = value; }
        public int ResistPoints { get => resistPoints; set => resistPoints = value; }
        public laffinitys Affinity { get => affinity; set => affinity = value; }
        internal List<Equip> Lequips { get => lequips; set => lequips = value; }

        public void UsarEquipo(Equip equip)
        {
            int contador = lequips.Count;
            Equip.Affinity afinidadEquipo = equip.Affinity1;

            if (contador < 3 && !Affinity.Equals(afinidadEquipo))
            {
               Lequips.Add(equip);
                if (equip.TargetAttribute1 == Equip.TargetAttribute.ALL)
                {
                    AttackPoints += (int)equip.EffectPoints;
                    ResistPoints += (int)equip.EffectPoints;
                }
                else if (equip.TargetAttribute1 == Equip.TargetAttribute.RP) ResistPoints += (int)equip.EffectPoints;

                else if (equip.TargetAttribute1 == Equip.TargetAttribute.AP) AttackPoints += (int)equip.EffectPoints;

            }
           
        }

        public void QuitarEquipo( Equip equip)
        {
           Lequips.RemoveAt(0);

            if (equip.TargetAttribute1 == Equip.TargetAttribute.ALL)
            {
                AttackPoints -= (int)equip.EffectPoints;
                ResistPoints -= (int)equip.EffectPoints;
            }
            else if (equip.TargetAttribute1 == Equip.TargetAttribute.RP) ResistPoints -= (int)equip.EffectPoints;

            else if (equip.TargetAttribute1 == Equip.TargetAttribute.AP) AttackPoints -= (int)equip.EffectPoints;

           
        }

    }
}
