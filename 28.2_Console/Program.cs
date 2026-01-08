using System.Xml.Serialization;
using _28._2;

namespace _28._2_Console
{
    internal class Program
    {
        static void Main(string[] args)
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

            var xmlSerializer = new XmlSerializer(typeof(Banca));

            TextWriter textWriter = new StreamWriter(filePath);

            xmlSerializer.Serialize(textWriter, banca);

            textWriter.Close();
        }
    }
}
