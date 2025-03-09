using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace SituatiiUrgenta
{
    class Program
    {
        //List<Angajat> angajati = Angajat.CitesteAngajatiDinFisier();
        //List<Urgente> urgente = Urgente.CitesteUrgenteDinFisier();
        //static string FisierUrgente = "urgente.txt";
        //const string FisierAngajati = "angajati.txt";
            static void Main()
            { 
                List<Angajat> angajati = Angajat.CitesteAngajatiDinFisier();
                List<Urgente> urgente = Urgente.CitesteUrgenteDinFisier();

                while (true)
                {
                    Console.WriteLine("\nMeniu:");
                    Console.WriteLine("1. Adauga Angajat");
                    Console.WriteLine("2. Afiseaza Angajati");
                    Console.WriteLine("3. Cautare Angajat");
                    Console.WriteLine("4. Salveaza Angajati in Fisier");
                    Console.WriteLine("5. Adauga Urgenta");
                    Console.WriteLine("6. Afiseaza Urgente");
                    Console.WriteLine("7. Cautare Urgenta");
                    Console.WriteLine("8. Salveaza Urgente in Fisier");
                    Console.WriteLine("0. Iesi");
                    Console.Write("Alegeti optiunea: ");
                    string optiune = Console.ReadLine() ?? string.Empty;

                    switch (optiune)
                    {
                        case "1":
                            Angajat.AdaugaAngajat(angajati);
                            break;
                        case "2":
                            Angajat.AfiseazaAngajati(angajati);
                            break;
                        case "3":
                            Angajat.CautaAngajatDupaNume(angajati);
                            break;
                        case "4":
                            Angajat.ScrieAngajatiInFisier(angajati);
                            break;
                        case "5":
                            Urgente.AdaugaUrgenta(urgente);
                            break;
                        case "6":
                            Urgente.AfiseazaUrgente(urgente);
                            break;
                        case "7":
                            Urgente.CautaUrgenta(urgente);
                            break;
                        case "8":
                            Urgente.ScrieUrgenteInFisier(urgente);
                            break;
                        case "0":
                            Console.WriteLine("Iesire din aplicatie...");
                            return;
                        default:
                            Console.WriteLine("Optiune invalida.");
                            break;
                    }
                }
            }
        }
    }