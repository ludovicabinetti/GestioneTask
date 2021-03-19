using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneTask
{
    enum Filtri
    {
        Basso,
        Medio,
        Alto,
        Nessuno
    }
    class TaskManager
    {
        private int _id = 0;

        private Dictionary<int, Task> _agenda = new Dictionary<int, Task>();
       
        public Task AggiungiTask(string descrizione, DateTime dataScadenza, LivelloImportanza livelloImportanza)
        {

            _agenda.Add(++_id, new Task(descrizione, dataScadenza, livelloImportanza, _id)); // lo inserisco in agenda

            return _agenda[_id];
        }
        public string VisualizzaTask(Filtri f)
        {
            string s = "";

            switch (f)
            {
                case Filtri.Basso:
                    foreach (int k in _agenda.Keys)
                        if (_agenda[k].Importanza == LivelloImportanza.Basso)
                            s += $"{k} - " + _agenda[k].Info() + "\n";
                    break;
                case Filtri.Medio:
                    foreach (int k in _agenda.Keys)
                        if (_agenda[k].Importanza == LivelloImportanza.Medio)
                        s += $"{k} - " + _agenda[k].Info() + "\n";
                    break;
                case Filtri.Alto:
                    foreach (int k in _agenda.Keys)
                        if (_agenda[k].Importanza == LivelloImportanza.Alto)
                        s += $"{k} - " + _agenda[k].Info() + "\n";
                    break;
                case Filtri.Nessuno:
                    foreach (int k in _agenda.Keys)
                        s += $"{k} - " + _agenda[k].Info() + "\n";
                    break;
            }

            return s;

        }
        public Boolean Esiste(int id)
        {
            return _agenda.ContainsKey(id);
        }

        public void RimuoviTask(int id)
        {
            _agenda.Remove(id);
        }

    }
}
