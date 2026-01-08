using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28._2
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public double Stipendio { get; set; }

        public Cliente() { }

        public Cliente(string nome, string cognome, string codiceFiscale, double stipendio)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codiceFiscale;
            Stipendio = stipendio;
        }

        public override string ToString()
        {
            return $"{Nome} {Cognome} - CF: {CodiceFiscale} - Stipendio: {Stipendio}";
        }
    }
}
