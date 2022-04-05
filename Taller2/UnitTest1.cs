using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Taller2
{
    public class Tests
    {

        Deck Deck1;
        Player playerTest =new Player();
        List<Card> l_cards = new List<Card>();
        List<Equip> l_equips = new List<Equip> ();
        

       
        [TearDown]
        public void Reset()
        {
            Deck1 = null;
            l_cards.Clear();
            l_equips.Clear();
        }


        [Test]
        public void DeckLimitadoPorCostPoints()
        {

            Deck1 = playerTest.CrearDeck(l_cards);
            uint valor_inicial = Deck1.CostPoints;
            Character michi_warrior = playerTest.CrearCharacter1();

            playerTest.AgregarCartaAlDeck(Deck1, michi_warrior);

            //Valor inicial debe ser mayor al valos de los costpoints despues de agregar la carta esto verifica que el deck esta limitado por los 
            //cp y el cp del deck baja si meto una carta, tambien el metodo evalua si esta la cantidad maxima de characters,equips o supports
            Assert.IsTrue(valor_inicial > Deck1.CostPoints);           
                
        }

        [Test]
        public void CartaSoloSeAgregaSiHaySuficienteCP()
        {
            Deck1 = new Deck(l_cards, 0);
            Character michi_warrior = playerTest.CrearCharacter1();

            //Esta prueba verifica que no se pueda meter mas cartas si el cp es menor al cp de la carta
            Assert.IsFalse(playerTest.SepuedeAgregar(Deck1, michi_warrior));
        }

        [Test]
        public void CartaSupportSoloDestruyeUnEquipo()
        {
            Character prueba = playerTest.CrearCharacter();
            SupportSkill support1 = new SupportSkill("Capa", SupportSkill.lrarety.Rare, 3, SupportSkill.l_EffectType.DestroyEquip, 0);
            Equip equipo1 = new Equip("Casco", Equip.lrarety.Common, 2, Equip.TargetAttribute.ALL, Equip.Affinity.Knight, 2);
            Equip equipo2 = new Equip("Casco", Equip.lrarety.Common, 2, Equip.TargetAttribute.ALL, Equip.Affinity.Knight, 2);
            prueba.UsarEquipo(equipo1);
            prueba.UsarEquipo(equipo1);

            int equiposIniciales = prueba.Lequips.Count;
            

            prueba =playerTest.UsarSupport(prueba, support1);

            Assert.IsTrue(prueba.Lequips.Count < equiposIniciales);


        }


    }
}