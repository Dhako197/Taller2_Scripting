using NUnit.Framework;

namespace Taller2
{
    public class Tests
    {

        Deck Deck1;
        Player playerTest;
       
       
        [TearDown]
        public void Reset()
        {

        }


        [Test]
        public void DeckLimitadoPorCostPoints()
        {
            
            Deck1 = playerTest.CrearDeck(45);
            uint valor_inicial = Deck1.CostPoints;
            Character michi_warrior = playerTest.CrearCharacter();

            playerTest.AgregarCartaAlDeck(Deck1, michi_warrior);

            //Valor inicial debe ser mayor al valos de los costpoints despues de agregar la carta
            Assert.IsTrue(valor_inicial > Deck1.CostPoints);

            Assert.IsTrue(1 < 5);
                
        }
    }
}