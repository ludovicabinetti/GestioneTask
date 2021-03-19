using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneTask
{
    enum LivelloImportanza
    {
        Basso,
        Medio,
        Alto
    }
    class Task
    {
        public string Descrizione { get; }

        public DateTime DataScadenza { get; }

        public LivelloImportanza Importanza { get; }

        public int ID { get; }

        public Task(string descrizione, DateTime dataScadenza, LivelloImportanza importanza, int id)
        {
            Descrizione = descrizione;
            DataScadenza = dataScadenza;
            Importanza = importanza;
            ID = id;
        }

        public string Info()
        {
            return $"Descrizione: {Descrizione}; Data Scadenza: {DataScadenza.ToShortDateString()}; Livello di importanza: {Importanza}";
        }

    }
}
