using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2_Scripting.Clases
{
    class Player
    {
        public Card CrearCharacrter (Card card)
        {
            var randomP = new Random().Next(0, 8);
            var randomCP = new Random().Next(2, 6);
            var randomRare1 = new Random().Next(1,5);
            var randomRare2 = new Random().Next(1, 5);
            var randomRare3 = new Random().Next(1, 5);

            Character char1 = new Character();
            Character char2 = new Character();
            Character char3 = new Character();

            char1.AttackPoints = randomP;
            char1.CostPoint = randomCP;
            char1.ResistPoints = randomP;
            char1.Affinity = laffinitys.Knight;

            switch (randomRare1)
            {
                case 1:
                    char1.Rarety = Character.lrarety.Common;
                    break;
                case 2:
                    char1.Rarety = Character.lrarety.Rare;
                    break;
                case 3:
                    char1.Rarety = Character.lrarety.SuperRare;
                    break;
                case 4:
                    char1.Rarety = Character.lrarety.UltraRare;
                    break;
            }

            char2.AttackPoints = randomP;
            char2.CostPoint = randomCP;
            char2.ResistPoints = randomP;
            char2.Affinity = laffinitys.Mage;

            switch (randomRare2)
            {
                case 1:
                    char2.Rarety = Character.lrarety.Common;
                    break;
                case 2:
                    char2.Rarety = Character.lrarety.Rare;
                    break;
                case 3:
                    char2.Rarety = Character.lrarety.SuperRare;
                    break;
                case 4:
                    char2.Rarety = Character.lrarety.UltraRare;
                    break;
            }

            char3.AttackPoints = randomP;
            char3.CostPoint = randomCP;
            char3.ResistPoints = randomP;
            char3.Affinity = laffinitys.Undead;

            switch (randomRare3)
            {
                case 1:
                    char3.Rarety = Character.lrarety.Common;
                    break;
                case 2:
                    char3.Rarety = Character.lrarety.Rare;
                    break;
                case 3:
                    char3.Rarety = Character.lrarety.SuperRare;
                    break;
                case 4:
                    char3.Rarety = Character.lrarety.UltraRare;
                    break;
            }

        }
         public Card CrearCartaEquip( Card cad)
        {
            var randomCP = new Random().Next(2, 6);
            var randomEP = new Random().Next(1, 4);
            var randomRare1 = new Random().Next(1, 5);
            var randomRare2 = new Random().Next(1, 5);
            var randomRare3 = new Random().Next(1, 5);
            var randomTAK = new Random().Next(1, 4);
            var randomTAM = new Random().Next(1, 4);
            var randomTAU = new Random().Next(1, 4);

            Equip eq1 = new Equip();
            Equip eq2 = new Equip();
            Equip eq2 = new Equip();

            eq1.CostPoint = randomCP;
            eq1.affinity = affinity.Knight;
            eq1.effectPoints = randomEP;

            switch (randomTAK)
            {
                case 1:
                    eq1.targetAttribute = Equip.TargetAttribute.ALL;
            }

        }

        public Deck AgregarCartaAlDEck (Deck deck,Card card)
        {
            int cantidadCharacter;
            int cantidadEquip;
            int cantidadSupport;

           // foreach ()



            if (deck.CostPoints > 0 && card.CostPoint <= deck.CostPoints)
            {
               
                deck.Lcards.add(card);
                deck.CostPoints -= card.CostPoint; 
            }
            
            return deck;
        }



    }
}
