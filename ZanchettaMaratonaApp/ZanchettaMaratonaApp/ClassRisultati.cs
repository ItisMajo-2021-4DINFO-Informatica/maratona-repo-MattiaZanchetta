using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZanchettaMaratonaApp
{
    class ClassRisultati
    {
        public List<ClassRisultato> ListaRisultati { get; set; }

        public ClassRisultati()
        {
            ListaRisultati = new List<ClassRisultato>();
        }

        public void AggiungiLinea(ClassRisultato risultato)
        {
            ListaRisultati.Add(risultato);
        }

        public string TrasformaTempo(ClassRisultato risultato)
        {
            string temp = risultato.Tempo;
            int char1 = temp.IndexOf("h");

            string temp1 = temp.Substring(0, char1);
            string temp2 = temp.Substring(char1 + 1, 2);

            int finaleTempInt = Int16.Parse(temp1) * 60 + Int16.Parse(temp2);
            string finaleTemp = finaleTempInt.ToString();
            return finaleTemp;
        }

        public string CercaAtleti(string inpCitta)
        {
            var lista2 = new List<string>();
            string listaAtleti = "";

            foreach (var citta in this.ListaRisultati)
            {
                if (inpCitta == citta.CittaMaratona.ToLower())
                {
                    lista2.Add(citta.NomeAtleta);
                }
            }

            foreach (string atleti in lista2)
            {
                listaAtleti += $"{atleti}, ";
            }
            return listaAtleti;
        }
    }
    }
