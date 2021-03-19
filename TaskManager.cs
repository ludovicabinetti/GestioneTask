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

        public bool ControllaData(int giorno, int mese, int anno)
        {   
            if (mese > 0 && mese <= 12)
                if (giorno > 0 && giorno < DateTime.DaysInMonth(anno, mese))
                {
                    DateTime scadenza = new DateTime(anno, mese, giorno);
                    if (DateTime.Today <= scadenza)
                        return true;
                }

            return false;
                    
        }
        //public bool ControllaData(DateTime scadenza)
        //{
        //    if (DateTime.Today >= scadenza)
        //        return true;
        //    return false;
        //}

        //public bool ControllaData(DateTime scadenza)
        //{
        //    if (scadenza.Day > 0 && scadenza.Day < DateTime.DaysInMonth(scadenza.Year, scadenza.Month))
        //        return true;
        //    return false;
        //}

        public void AggiungiTask(string descrizione, DateTime dataScadenza, LivelloImportanza livelloImportanza)
        {

            int id = ++_id; // assegno un id al task
            _agenda.Add(id, new Task(descrizione, dataScadenza, livelloImportanza, id)); // lo inserisco in agenda
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
