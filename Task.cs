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

        private int _id;

        public Task(string descrizione, DateTime dataScadenza, LivelloImportanza importanza, int id)
        {
            Descrizione = descrizione;
            DataScadenza = dataScadenza;
            Importanza = importanza;
            _id = id;
        }

        public string Info()
        {
            return $"Descrizione: {Descrizione}; Data Scadenza: {DataScadenza.Date}; Livello di importanza: {Importanza}";
        }

    }
}
