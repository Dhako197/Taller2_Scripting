using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2
{
    internal class Player
    {
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
            if (deck.CostPoints > card.CostPoint)
            {
                return true;
            }
            else return false;




        }

    }
}
