using _28._2;

namespace _28._2_Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Test_TotalePrestiti()
        {
            Cliente cliente = new Cliente("Mario", "Rossi", "MRARSS80A01H501U", 30000);
            var clienti = new List<Cliente> { cliente };

            var prestito = new Prestito(10000, 500, new DateTime(2022, 1, 1), new DateTime(2025, 1, 1), cliente);

            var banca = new Banca("Banca Test");
            banca.AddPrestito(prestito);

            Assert.AreEqual(banca.TotalePrestiti("MRARSS80A01H501U"), 10000);
        }

        [TestMethod]
        public void Test_SearchPrestiti()
        {
            Cliente cliente = new Cliente("Mario", "Rossi", "MRARSS80A01H501U", 30000);
            var clienti = new List<Cliente> { cliente };

            var prestito = new Prestito(10000, 500, new DateTime(2022, 1, 1), new DateTime(2025, 1, 1), cliente);

            var banca = new Banca("Banca Test");

            banca.AddPrestito(prestito);           

            Assert.AreEqual(banca.SearchPrestiti("MRARSS80A01H501U").Count, 1);            
        }

        [TestMethod]
        public void Test_AddCliente()
        {
            Cliente cliente = new Cliente("Mario", "Rossi", "MRARSS80A01H501U", 30000);
            Cliente clienteAggiuntivo = new Cliente("Mario", "Rossi", "MRARSS80A01H501U", 30000);                        

            var banca = new Banca("Banca Test");
            banca.AddCliente(cliente);

            Assert.ThrowsException<InvalidOperationException>(() => banca.AddCliente(clienteAggiuntivo));
        }
    }
}
