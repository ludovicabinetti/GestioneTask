using System;
using System.IO;

namespace GestioneTask
{
    class Program
    {
        // creo l'oggetto TaskManager che viene gestito dal programma
        private static TaskManager agenda = new TaskManager();

        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel tuo Task Manager!");
            Console.WriteLine();
           
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Vedi i tuoi task");
                Console.WriteLine("2. Aggiungi un nuovo task");
                Console.WriteLine("3. Elimina un task");
                Console.WriteLine("4. Filtra i task per importanza");
                Console.WriteLine("5. Salva");
                Console.WriteLine("0. Esci");

                switch(Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.WriteLine();
                        VisualizzaTask();
                        break;
                    case '2':
                        Console.WriteLine();
                        AggiungiTask();
                        break;
                    case '3':
                        Console.WriteLine();
                        EliminaTask();
                        break;
                    case '4':
                        Console.WriteLine();
                        Filtra();
                        break;
                    case '5':
                        Console.WriteLine();
                        Salva();
                        break;
                    case '0':
                        return; // si esce dal programma
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

            } while (true);


        }

        private static void Salva()
        {
            const string fileName = @"agenda.txt"; // nome del file
           
            using (StreamWriter sw = new StreamWriter(fileName))
                sw.WriteLine(agenda.VisualizzaTask(Filtri.Nessuno));
            Console.WriteLine("Salvataggio avvenuto correttamente.");
        }

        private static void Filtra()
        {

            bool controllo = false;
            
            do
            {
                Console.WriteLine("Filtra per: \n 1. Livello di importanza Basso" +
                                              "\n 2. Livello di importanza Medio" +
                                              "\n 3. Livello di importanza Alto" +
                                              "\n 4. Visualizza tutti");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1': Console.WriteLine(agenda.VisualizzaTask(Filtri.Basso)); controllo = true; break;
                    case '2': Console.WriteLine(agenda.VisualizzaTask(Filtri.Medio)); controllo = true; break;
                    case '3': Console.WriteLine(agenda.VisualizzaTask(Filtri.Alto)); controllo = true; break;
                    case '4': Console.WriteLine(agenda.VisualizzaTask(Filtri.Nessuno)); controllo = true; break;
                    default:
                        Console.WriteLine("\nCarattere inserito non valido. Riprova");
                        break;
                }
            } while (!controllo);
           
            
        }

        private static void VisualizzaTask()
        {
            Console.WriteLine(agenda.VisualizzaTask(Filtri.Nessuno));
        }

        private static void EliminaTask()
        {
            Console.WriteLine("Quale task vuoi eliminare?");
            Console.WriteLine(agenda.VisualizzaTask(Filtri.Nessuno));

            int id;
            do
            {
                Console.WriteLine("Inserisci il numero corrispondente: ");
            } while (!int.TryParse(Console.ReadLine(), out id));

            if (agenda.Esiste(id))
            {
                agenda.RimuoviTask(id);
                Console.WriteLine("Task eliminato correttamente");
            }

        }

        // funzione che gestisce I/O con l'utente (effettuando alcuni controlli)
        // e che si appoggia alla classe TaskManager per inserire un nuovo task in agenda
        private static void AggiungiTask()
        {
            Console.WriteLine("Attribuisci una descrizione al tuo task: ");
            string descrizione = Console.ReadLine();

            int giorno;
            int mese;
            int anno;
            Console.WriteLine("Inserire data di scadenza.");
            do
            {
                Console.WriteLine("Inserisci giorno (dd): ");
            } while (!int.TryParse(Console.ReadLine(), out giorno));
            do
            {
                Console.WriteLine("Inserisci mese (es. 6, 10): ");
            } while (!int.TryParse(Console.ReadLine(), out mese));
            do
            {
                Console.WriteLine("Inserisci anno (aaaa): ");
            } while (!int.TryParse(Console.ReadLine(), out anno));

            // se la data inserita è valida, procedo con la richiesta di info all'utente
            if (agenda.ControllaData(giorno, mese, anno))
            {
                DateTime scadenza = new DateTime(anno, mese, giorno);
                bool controllo = false;
                LivelloImportanza livelloImportanza;
                do
                {
                    Console.WriteLine("Imposta un livello di difficolta (b/m/a)");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.B: livelloImportanza = LivelloImportanza.Basso; controllo = true; break;
                        case ConsoleKey.M: livelloImportanza = LivelloImportanza.Medio; controllo = true; break;
                        case ConsoleKey.A: livelloImportanza = LivelloImportanza.Alto; controllo = true; break;
                        default:
                            livelloImportanza = LivelloImportanza.Basso; // assegno valore arbitrario
                            Console.WriteLine("\nCarattere inserito non valido. Riprova");
                            break;
                    }
                } while (!controllo);

                agenda.AggiungiTask(descrizione, scadenza, livelloImportanza);

                Console.WriteLine("\nTask aggiunto correttamente alla tua agenda");
            }
            else
                Console.WriteLine("Data inserita non valida");

        }
    }
}
