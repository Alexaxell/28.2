using _28._2;
using System.Text.Json;
using System.Xml.Serialization;

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

        [TestMethod]
        public void Test_SearchCliente()
        {
            var cliente = new Cliente("Mario", "Rossi", "MRARSS80A01H501U", 30000);    
            
            var banca = new Banca("Banca Test");
            banca.AddCliente(cliente);

            var risultato = banca.SearchCliente("MRARSS80A01H501U");

            Assert.IsNotNull(risultato);
            Assert.AreEqual(risultato.CodiceFiscale, "MRARSS80A01H501U");
        }

        [TestMethod]
        public void Test_SearchCliente_NotFound()
        {
            var banca = new Banca("Banca Test");
            var risultato = banca.SearchCliente("NONEXISTENTCODE");
            Assert.IsNull(risultato);
        }

        [TestMethod]
        public void Serializzazzione()
        {
            var mario = new Cliente("Mario", "Rossi", "cfysbvfyvuvbvuvi", 1500);
            var enzo = new Cliente("Enzo", "Ferrari", "yevfeyufvoyfuew", 400000);
            var super = new Cliente("Super", "Mario", "bvybsvvbuvrev", 4000);
            var vasco = new Cliente("Vasco", "Rossi", "gfyrfbryuvfbrv", 3000);
            var travis = new Cliente("Travis", "Scott", "gryvurgyuvyreyvu", 200000);

            var clienti = new List<Cliente>()
            {
                mario, enzo, super, vasco, travis
            };

            var prestiti = new List<Prestito>()
            {
                new Prestito(1000, 100, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), mario),
                new Prestito(3000000, 3000, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), enzo),
                new Prestito(2000, 200, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), super),
                new Prestito(1500, 125, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), vasco),
                new Prestito(40000, 4000, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), travis)
            };

            var banca = new Banca("Banca");
            
            foreach(var prestito in prestiti)
            {
                banca.AddPrestito(prestito);
            }

            foreach(var cliente in clienti)
            {
                banca.AddCliente(cliente);
            }

            string filePath = @"C:\Users\10228\Desktop\cartellaaa\serializzazioneBanca.txt";

            var xmlSerializer = new XmlSerializer(typeof(Banca));

            TextWriter textWriter = new StreamWriter(filePath);

            xmlSerializer.Serialize(textWriter, banca);

            textWriter.Close();

            var streamReader = new StreamReader(filePath);
            
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                Console.WriteLine(line);
            }
        }

        [TestMethod]
        public void JSON()
        {
            var mario = new Cliente("Mario", "Rossi", "cfysbvfyvuvbvuvi", 1500);
            var enzo = new Cliente("Enzo", "Ferrari", "yevfeyufvoyfuew", 400000);
            var super = new Cliente("Super", "Mario", "bvybsvvbuvrev", 4000);
            var vasco = new Cliente("Vasco", "Rossi", "gfyrfbryuvfbrv", 3000);
            var travis = new Cliente("Travis", "Scott", "gryvurgyuvyreyvu", 200000);

            var clienti = new List<Cliente>()
            {
                mario, enzo, super, vasco, travis
            };

            var prestiti = new List<Prestito>()
            {
                new Prestito(1000, 100, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), mario),
                new Prestito(3000000, 3000, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), enzo),
                new Prestito(2000, 200, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), super),
                new Prestito(1500, 125, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), vasco),
                new Prestito(40000, 4000, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), travis)
            };

            var banca = new Banca("Banca");

            foreach (var prestito in prestiti)
            {
                banca.AddPrestito(prestito);
            }

            foreach (var cliente in clienti)
            {
                banca.AddCliente(cliente);
            }

            string filePath = @"C:\Users\10228\Desktop\cartellaaa\serializzazioneBanca.txt";

            var options = new JsonSerializerOptions
            {
                WriteIndented = true // JSON leggibile
            };

            string json = JsonSerializer.Serialize(banca, options);
            File.WriteAllText(filePath, json);

            Console.WriteLine(json);
        }
    }
}
