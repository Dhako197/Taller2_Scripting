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
            

            string afinidadCaharcter = Affinity.ToString();
            string afinidadEquip = equip.Affinity1.ToString();



            if (contador < 3 && afinidadCaharcter.Equals(afinidadEquip)) 
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

        public Character  Atacar(Character target)
        {

            string afinidadCaharcter = Affinity.ToString();
            string afinidadTarget = target.affinity.ToString();
            string afinidadMage = Character.laffinitys.Mage.ToString();
            string afinidadUndead = Character.laffinitys.Undead.ToString();
            string afinidadKnight= Character.laffinitys.Knight.ToString();

            if (afinidadCaharcter.Equals(afinidadTarget))
            {
                target.resistPoints -= AttackPoints;
                ResistPoints -= target.AttackPoints;
                return target;
               
            }
            else if(afinidadCaharcter.Equals(afinidadMage)&& afinidadTarget.Equals(afinidadUndead))
            {
                target.resistPoints--;
                target.resistPoints  -= (AttackPoints+1);
                ResistPoints -= target.AttackPoints;
                return target;
            }
            else if (afinidadCaharcter.Equals(afinidadMage) && afinidadTarget.Equals(afinidadKnight))
            {
                target.resistPoints -= AttackPoints;
                ResistPoints--;
                ResistPoints -= target.AttackPoints + 1;
                return target;
            }
            else if (afinidadCaharcter.Equals(afinidadUndead) && afinidadTarget.Equals(afinidadMage))
            {
                target.resistPoints -= AttackPoints;
                ResistPoints--;
                ResistPoints -= target.AttackPoints +1;
                return target;
            }
            else if (afinidadCaharcter.Equals(afinidadUndead) && afinidadTarget.Equals(afinidadKnight))
            {
                target.resistPoints--;
                target.resistPoints -= (AttackPoints + 1);
                ResistPoints -= target.AttackPoints;
                return target;
            }
            else if (afinidadCaharcter.Equals(afinidadKnight) && afinidadTarget.Equals(afinidadMage))
            {
                target.resistPoints--;
                target.resistPoints -= (AttackPoints + 1);
                ResistPoints -= target.AttackPoints;
                return target;
            }
            else if (afinidadCaharcter.Equals(afinidadKnight) && afinidadTarget.Equals(afinidadUndead))
            {
                target.resistPoints -= AttackPoints;
                ResistPoints--;
                ResistPoints -= target.AttackPoints + 1;
                return target;
            }

            return target;

        }



    }
}
