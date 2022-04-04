using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2
{
    internal class Player
    {

        public Character CrearCharacter1()
        {
            
            Character charac = null;

            Random randomAP = new Random();
            uint rndAP = (uint)randomAP.Next(1,6);
            Random randomRP = new Random();
            uint rndRP = (uint)randomRP.Next(1,6);
            Random randomCP = new Random();
            uint rndCP = (uint)randomCP.Next(1,6);

            

            charac.AttackPoints = rndAP;
            charac.ResistPoints = rndRP;
            charac.CostPoint = rndCP;

            Array valuesAffi = Enum.GetValues(typeof(Character.laffinitys));
            Random randomAffi = new Random();
            Character.laffinitys randomAffinity = (Character.laffinitys)randomAffi.Next(valuesAffi.Length);

            Array valuesRare = Enum.GetValues(typeof(Character.lrarety));
            Random randomRare = new Random();
            Character.lrarety randomRarety = (Character.lrarety)randomRare.Next(valuesRare.Length);


            return charac;
        }
        public Equip CrearEquip()
        {
            Equip equip = null;

            Random randomEP = new Random();
            uint rndEP = (uint)randomEP.Next(1, 6);
            Random randomCP = new Random();
            uint rndCP = (uint)randomCP.Next(1, 6);

            equip.EffectPoints = rndEP;
            equip.CostPoint = rndCP;

            Array valuesAffi = Enum.GetValues(typeof(Equip.Affinity));
            Random randomAffi = new Random();
            Equip.Affinity randomAffinity = (Equip.Affinity)randomAffi.Next(valuesAffi.Length);

            Array valuesTarg = Enum.GetValues(typeof(Equip.TargetAttribute));
            Random randomTarg = new Random();
            Equip.TargetAttribute randomTargget = (Equip.TargetAttribute)randomTarg.Next(valuesTarg.Length);

            Array valuesRare = Enum.GetValues(typeof(Equip.lrarety));
            Random randomRare = new Random();
            Equip.lrarety randomRarety = (Equip.lrarety)randomRare.Next(valuesRare.Length);

            return equip;
        }
         public SupportSkill CrearsupportSkill()
        {
            SupportSkill supportskill = null;

            Random randomEP = new Random();
            int rndEP = (int)randomEP.Next(1, 6);
            
            Random randomCP = new Random();
            uint rndCP = (uint)randomCP.Next(1, 6);

            supportskill.EffectPoints = rndEP;
            supportskill.CostPoint = rndCP;

            Array valuesEffect = Enum.GetValues(typeof(SupportSkill.l_EffectType));
            Random randomEff = new Random();
            SupportSkill.l_EffectType randomEffect = (SupportSkill.l_EffectType)randomEff.Next(valuesEffect.Length);

            Array valuesRare = Enum.GetValues(typeof(SupportSkill.lrarety));
            Random randomRare = new Random();
            SupportSkill.lrarety randomRarety = (SupportSkill.lrarety)randomRare.Next(valuesRare.Length);

            return supportskill;
        }
        public Deck AgregarCartaAlDeck(Deck deck, Card card)
        {
            int cantidadCharacter = 0;
            int cantidadEquip = 0;
            int cantidadSupport = 0;

            foreach (Card element in deck.Lcards)
            {
                if (element is Character) cantidadCharacter++;
                else if (element is Equip) cantidadEquip++;
                else cantidadSupport++;
            }

            if (card is Character && cantidadCharacter < 5 && deck.CostPoints > 0 && card.CostPoint <= deck.CostPoints)
            {
                deck.Lcards.Add(card);
                deck.CostPoints -= card.CostPoint;
            }
            else if (card is Equip && cantidadEquip < 10 && deck.CostPoints > 0 && card.CostPoint <= deck.CostPoints)
            {
                deck.Lcards.Add(card);
                deck.CostPoints -= card.CostPoint;
            }
            else if (card is SupportSkill && cantidadSupport < 5 && deck.CostPoints > 0 && card.CostPoint <= deck.CostPoints)
            {
                deck.Lcards.Add(card);
                deck.CostPoints -= card.CostPoint;
            }

            return deck;
        }

       

        public Character CrearCharacter()
        {
            List<Equip> l_equips = new List<Equip>();
            Character michi_warrior = new Character("Michi Guerrero", Character.lrarety.UltraRare, 4, 5, 5, l_equips, Character.laffinitys.Knight);
            return michi_warrior;
        }

        public bool SepuedeAgregar(Deck deck, Card card)
        {
            if (deck.CostPoints >= card.CostPoint)
            {
                return true;
            }
            else return false;

        }
        public Deck CrearDeck(List<Card> cards)
        {
           

            Deck deck = new Deck(cards, 45);

            return deck;

        }
        public Character UsarSupport(Character target, SupportSkill support)
        {


            return target;
        }



    }
}
