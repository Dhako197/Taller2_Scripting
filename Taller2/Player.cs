﻿using System;
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

        public Deck CrearDeck(uint costPoint)
        {
            List<Card> l_cards = new List<Card>();

            Deck deck = new Deck(l_cards, costPoint);

            return deck;

        }
    }
}
