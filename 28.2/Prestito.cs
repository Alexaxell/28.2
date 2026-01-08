using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _28._2
{
    public class Prestito
    {
        public double Ammontare { get; set; }
        public double Rata { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        [XmlIgnore]
        public Cliente Intestatario { get; set; }

        public Prestito() { }

        public Prestito(double ammontare, double rata, DateTime dataInizio, DateTime dataFine, Cliente intestatario)
        {
            Ammontare = ammontare;
            Rata = rata;
            DataInizio = dataInizio;
            DataFine = dataFine;
            Intestatario = intestatario;
        }

        public override string ToString()
        {
            return $"Prestito di {Ammontare} a {Intestatario.Nome} {Intestatario.Cognome}, Rata: {Rata}, Inizio: {DataInizio.ToShortDateString()}, Fine: {DataFine.ToShortDateString()}";
        }
    }
}
