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
            
            Character charac;
            Random randomName = new Random();
            int numero= randomName.Next(26);
            char letra = (char)(((int)'A') + numero);
            string name = ("Charcter " + letra);

            List<Equip> l_equips = new List<Equip>(3);

            Random randomAP = new Random();
            int rndAP = randomAP.Next(1,6);
            Random randomRP = new Random();
            int rndRP = randomRP.Next(1,6);
            Random randomCP = new Random();
            uint rndCP = (uint)randomCP.Next(1,6);

            

            

            Array valuesAffi = Enum.GetValues(typeof(Character.laffinitys));
            Random randomAffi = new Random();
            Character.laffinitys randomAffinity = (Character.laffinitys)randomAffi.Next(valuesAffi.Length);

            Array valuesRare = Enum.GetValues(typeof(Character.lrarety));
            Random randomRare = new Random();
            Character.lrarety randomRarety = (Character.lrarety)randomRare.Next(valuesRare.Length);

            charac = new Character(name, randomRarety, rndCP, rndAP, rndRP, l_equips, randomAffinity);


            return charac;
        }
        public Equip CrearEquip()
        {
            Equip equip;

            Random randomName = new Random();
            int numero = randomName.Next(26);
            char letra = (char)(((int)'A') + numero);
            string name = ("Charcter " + letra);

            Random randomEP = new Random();
            uint rndEP = (uint)randomEP.Next(1, 6);
            Random randomCP = new Random();
            uint rndCP = (uint)randomCP.Next(1, 6);

            

            Array valuesAffi = Enum.GetValues(typeof(Equip.Affinity));
            Random randomAffi = new Random();
            Equip.Affinity randomAffinity = (Equip.Affinity)randomAffi.Next(valuesAffi.Length);

            Array valuesTarg = Enum.GetValues(typeof(Equip.TargetAttribute));
            Random randomTarg = new Random();
            Equip.TargetAttribute randomTargget = (Equip.TargetAttribute)randomTarg.Next(valuesTarg.Length);

            Array valuesRare = Enum.GetValues(typeof(Equip.lrarety));
            Random randomRare = new Random();
            Equip.lrarety randomRarety = (Equip.lrarety)randomRare.Next(valuesRare.Length);

            equip = new Equip(name, randomRarety, rndCP, randomTargget, randomAffinity, rndEP);

            return equip;
        }
         public SupportSkill CrearsupportSkill()
        {
            SupportSkill supportskill;

            Random randomName = new Random();
            int numero = randomName.Next(26);
            char letra = (char)(((int)'A') + numero);
            string name = ("Charcter " + letra);

            Random randomEP = new Random();
            int rndEP = (int)randomEP.Next(1, 6);
            
            Random randomCP = new Random();
            uint rndCP = (uint)randomCP.Next(1, 6);

            

            Array valuesEffect = Enum.GetValues(typeof(SupportSkill.l_EffectType));
            Random randomEff = new Random();
            SupportSkill.l_EffectType randomEffect = (SupportSkill.l_EffectType)randomEff.Next(valuesEffect.Length);

            Array valuesRare = Enum.GetValues(typeof(SupportSkill.lrarety));
            Random randomRare = new Random();
            SupportSkill.lrarety randomRarety = (SupportSkill.lrarety)randomRare.Next(valuesRare.Length);

            supportskill = new SupportSkill(name, randomRarety, rndCP, randomEffect, rndEP);

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
            if (support.EffectType == SupportSkill.l_EffectType.DestroyEquip)
            {
                if (target.Lequips.Count > 0)
                {
                    target.QuitarEquipo( target.Lequips[0]);
                    //target.Lequips.Remove(target.Lequips[0]);
                }
            }
            else if(support.EffectType == SupportSkill.l_EffectType.RestoreRP)
            {
                target.ResistPoints += support.EffectPoints;

            }
            else if(support.EffectType == SupportSkill.l_EffectType.ReduceAll)
            {
                target.ResistPoints -= support.EffectPoints;
                target.AttackPoints -= support.EffectPoints;
            }
            else if(support.EffectType == SupportSkill.l_EffectType.ReduceRP)
            {
                target.ResistPoints-=support.EffectPoints;
            }

            return target;
        }

        public Character PuedeContinuar (Character character)
        {
            if(character.ResistPoints<=0) character=null; 
            return character;
        }

        public bool DeckDisponibleParaJugar(Deck deck)
        {
            int cantidadCharacter = 0;
            int cantidadEquip = 0;
            int cantidadSupport = 0;

            foreach (Card element in deck.Lcards)
            {
                if (element is Character&& element != null) cantidadCharacter++;
                else if (element is Equip) cantidadEquip++;
                else cantidadSupport++;
            }
            if (cantidadCharacter == 0 || cantidadCharacter > 5 || cantidadEquip > 10 || cantidadSupport > 5) return false;

            return true;



        }

       public Card Gacha()
       {

          Random random = new Random();

            int valorGacha = random.Next(1, 1001);

            if(1<= valorGacha&& valorGacha <= 5)
            {
                Character premioGacha = CrearCharacter1();
                premioGacha.Rarety = Character.lrarety.UltraRare;
                return premioGacha;
            }
            else if (5< valorGacha&& valorGacha <= 30)
            {
                Character premioGacha = CrearCharacter1();
                premioGacha.Rarety = Character.lrarety.SuperRare;
                return premioGacha;
            }
            else if (30 < valorGacha && valorGacha <= 80)
            {
                Character premioGacha = CrearCharacter1();
                premioGacha.Rarety = Character.lrarety.Rare;
                return premioGacha;
            }
            else if (80 < valorGacha && valorGacha <= 200)
            {
                Character premioGacha = CrearCharacter1();
                premioGacha.Rarety = Character.lrarety.Common;
                return premioGacha;
            }

            else if (200 < valorGacha && valorGacha <= 205)
            {
                Equip premioGacha = CrearEquip();
                premioGacha.Rarety = Equip.lrarety.UltraRare;
                return premioGacha;
            }
            else if (205 < valorGacha && valorGacha <= 230)
            {
                Equip premioGacha = CrearEquip();
                premioGacha.Rarety = Equip.lrarety.SuperRare;
                return premioGacha;
            }
            else if (230 < valorGacha && valorGacha <= 300)
            {
                Equip premioGacha = CrearEquip();
                premioGacha.Rarety = Equip.lrarety.Rare;
                return premioGacha;
            }
            else if (300 < valorGacha && valorGacha <= 500)
            {
                Equip premioGacha = CrearEquip();
                premioGacha.Rarety = Equip.lrarety.Common;
                return premioGacha;
            }
            else if (500 < valorGacha && valorGacha <= 505)
            {
                SupportSkill premioGacha = CrearsupportSkill();
                premioGacha.Rarety = SupportSkill.lrarety.UltraRare;
                return premioGacha;
            }
            else if (505 < valorGacha && valorGacha <= 530)
            {
                SupportSkill premioGacha = CrearsupportSkill();
                premioGacha.Rarety = SupportSkill.lrarety.SuperRare;
                return premioGacha;
            }
            else if (530 < valorGacha && valorGacha <=730)
            {
                SupportSkill premioGacha = CrearsupportSkill();
                premioGacha.Rarety = SupportSkill.lrarety.Rare;
                return premioGacha;
            }
            else if (730 < valorGacha && valorGacha <= 1000)
            {
                SupportSkill premioGacha = CrearsupportSkill();
                premioGacha.Rarety = SupportSkill.lrarety.Common;
                return premioGacha;
            }
            return null;

        }

    }
}
