namespace _28._2
{
    public class Banca
    {
        public string Nome { get; set; }
        public List<Cliente> Clienti { get; set; }
        public List<Prestito> Prestiti { get; set; }

        public Banca(string nome)
        {
            Nome = nome;
            Clienti = new List<Cliente>();
            Prestiti = new List<Prestito>();
        }

        public void AddPrestito(Prestito prestito)
        {
            Prestiti.Add(prestito);
        }

        public double TotalePrestiti(string codiceFiscale)
        {
            double totale = 0;
            
            foreach (var prestito in Prestiti)
            {
                if (prestito.Intestatario.CodiceFiscale == codiceFiscale)
                {
                    totale += prestito.Ammontare;
                }
            }
            return totale;
        }

        public List<Prestito> SearchPrestiti(string codiceFiscale)
        {
            List<Prestito> risultati = new List<Prestito>();
            
            foreach (var prestito in Prestiti)
            {
                if (prestito.Intestatario.CodiceFiscale == codiceFiscale)
                {
                    risultati.Add(prestito);
                }
            }
            return risultati;
        }

        public void AddCliente(Cliente cliente)
        {
            foreach (var c in Clienti)
            {
                if (c.CodiceFiscale == cliente.CodiceFiscale)
                {
                    throw new InvalidOperationException("Cliente già esistente.");                    
                }
            }

            Clienti.Add(cliente);
        }

        public void RemoveCliente(string codiceFiscale)
        {            
            foreach (var c in Clienti)
            {
                if (c.CodiceFiscale == codiceFiscale)
                {
                    Clienti.Remove(c);
                    return;
                }
            }
        }

        public Cliente SearchCliente(string codiceFiscale)
        {
            foreach (var c in Clienti)
            {
                if (c.CodiceFiscale == codiceFiscale)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
