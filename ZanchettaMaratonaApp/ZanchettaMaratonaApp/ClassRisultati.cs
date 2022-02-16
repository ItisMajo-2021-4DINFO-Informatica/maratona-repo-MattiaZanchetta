using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
    }
