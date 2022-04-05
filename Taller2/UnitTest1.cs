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
            //cp y el cp del deck baja si meto una carta
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

            //Equipamos 2 objetos al character y eliminamos uno, el resultado es que tenga menor cantidad de equipos que en el inicio
            Assert.IsTrue(prueba.Lequips.Count < equiposIniciales);


        }

        [Test]
        public void BarajaSoloHastaXCantidadPorTipoDeCarta()
        {
            Character prueba = playerTest.CrearCharacter1();
            Deck1 = playerTest.CrearDeck(l_cards);
            playerTest.AgregarCartaAlDeck(Deck1, prueba);
            playerTest.AgregarCartaAlDeck(Deck1, prueba);
            playerTest.AgregarCartaAlDeck(Deck1, prueba);
            playerTest.AgregarCartaAlDeck(Deck1, prueba);
            playerTest.AgregarCartaAlDeck(Deck1, prueba);

            int contadorInicial = Deck1.Lcards.Count;

            playerTest.AgregarCartaAlDeck(Deck1, prueba);

            int contadorFinal= Deck1.Lcards.Count;

            //Confirmamos que si tratamos de meter otro charapter no se pueda porque ya esta el maximo que en este caso es 5, se aplica la misma logica para los otros tipos de carta 
            Assert.IsTrue(contadorInicial == contadorFinal);
        
        }

        [Test]
        public void ReduccionDeRpDespuesDeAtaQue()
        {
            Character character1= playerTest.CrearCharacter1();
            Character character2 = playerTest.CrearCharacter1();

            int valorInicialRP = character2.ResistPoints;
            character2=character1.Atacar(character2);

            //Cofirmamos que el rp de la carta defensora redujo su rp despues de efectuar el ataque
            Assert.IsTrue(character2.ResistPoints < valorInicialRP);

        }
        [Test]
        public void PersonajeDestrudioConCeroRp()
        {
            Character character1 = new Character("Gran Zombie", Character.lrarety.Rare, 6, 7, 7, l_equips, Character.laffinitys.Undead);
            Character character2 = new Character("Mago igneo", Character.lrarety.Rare, 2, 1, 1, l_equips, Character.laffinitys.Mage);
            character2= character1.Atacar(character2);
            character2=playerTest.PuedeContinuar(character2);

            //Dentro de la logica del juego pusimos que si la carta esta nula esta no se pueda usar
            Assert.IsTrue(character2 == null);

        }

        [Test]
        public void JugadorPuedeSeguirJugando()
        {
            Character character = null;
            Character character2 = null;
            l_cards.Add(character);
            l_cards.Add(character2);
            Deck1 = playerTest.CrearDeck(l_cards);
            
            //Al tener un mazo no disponible el juagdor no puede continuar jugando por ende pierde
            Assert.IsFalse(playerTest.DeckDisponibleParaJugar(Deck1));
        }



    }
}