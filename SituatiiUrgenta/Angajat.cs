using System;
using System.Globalization;

namespace SituatiiUrgenta
{
    
    public class Angajat : Persoana
    {
        const string FisierAngajati = "angajati.txt";
        private string profesie;
        private int vechime;
        private string email;

        public Angajat() : base()
        {
            profesie = string.Empty;
            vechime = 0;
            email = string.Empty;
        }

        public Angajat(string nume, DateTime dataNasterii, string profesie, int vechime, string email)
            : base(nume, dataNasterii)
        {
            this.profesie = profesie;
            this.vechime = vechime;
            this.email = email;
        }

        public string Info()
        {
            return base.Info() + $",{profesie},{vechime},{email}";
        }

        public static Angajat FromString(string data)
        {
            string[] parts = data.Split(',');

            if (parts.Length != 5) return null;

            string nume = parts[0];
            DateTime dataNasterii = DateTime.ParseExact(parts[1], "dd/MM/yyyy", null);
            string profesie = parts[2];
            int vechime = int.Parse(parts[3]);
            string email = parts[4];

            return new Angajat(nume, dataNasterii, profesie, vechime, email);
        }
        public static void AdaugaAngajat(List<Angajat> angajati)
            {
                Console.Write("Introdu numele angajatului: ");
                string nume = Console.ReadLine() ?? string.Empty;

            DateTime dataNasterii;
            while (true)
            {
                Console.Write("Introdu data nasterii (format: dd/MM/yyyy): ");
                string inputData = Console.ReadLine() ?? string.Empty;
                if (DateTime.TryParseExact(inputData, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNasterii))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Data este invalida");
                }
            }

            Console.Write("Introdu profesia angajatului: ");
                string profesie = Console.ReadLine() ?? string.Empty;

                Console.Write("Introdu vechimea angajatului (in ani): ");
                int vechime = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Introdu email-ul angajatului: ");
                string email = Console.ReadLine() ?? string.Empty;

                angajati.Add(new Angajat(nume, dataNasterii, profesie, vechime, email));
                Console.WriteLine("Angajat adaugat cu succes!");
            }

            public static void AfiseazaAngajati(List<Angajat> angajati)
            {
                if (angajati.Count == 0)
                {
                    Console.WriteLine("Nu exista angajati.");
                    return;
                }

                Console.WriteLine("\nLista Angajatilor:");
                foreach (var angajat in angajati)
                {
                    Console.WriteLine(angajat.Info());
                }
            }

            public static void CautaAngajatDupaNume(List<Angajat> angajati)
            {
                Console.Write("Introdu numele angajatului cautat: ");
                string numeCautat = Console.ReadLine() ?? string.Empty;

                var rezultate = angajati.Where(a => a.Info().Contains(numeCautat, StringComparison.OrdinalIgnoreCase)).ToList();

                if (rezultate.Count == 0)
                {
                    Console.WriteLine("Nicio persoana gasita.");
                    return;
                }

                Console.WriteLine("\nAngajati gasiti:");
                foreach (var a in rezultate)
                {
                    Console.WriteLine(a.Info());
                }
            }

            public static void CautaAngajatDupaSpecializare(List<Angajat> angajati)
            {
                Console.Write("Introdu specializarea cautata: ");
                string specializareCautata = Console.ReadLine() ?? string.Empty;

                var rezultate = angajati.Where(a => a.Info().Contains(specializareCautata, StringComparison.OrdinalIgnoreCase)).ToList();

                if (rezultate.Count == 0)
                {
                    Console.WriteLine("Niciun angajat cu aceasta specializare.");
                    return;
                }

                Console.WriteLine("\nAngajati cu specializarea gasita:");
                foreach (var a in rezultate)
                {
                    Console.WriteLine(a.Info());
                }
            }

          
            public static List<Angajat> CitesteAngajatiDinFisier()
            {
                List<Angajat> angajati = new();
                if (File.Exists(FisierAngajati))
                {
                    foreach (var linie in File.ReadAllLines(FisierAngajati))
                    {
                        Angajat a = Angajat.FromString(linie);
                        if (a != null) angajati.Add(a);
                    }
                }
                return angajati;
            }


            public static void ScrieAngajatiInFisier(List<Angajat> angajati)
            {
                File.WriteAllLines(FisierAngajati, angajati.Select(a => a.Info()));
                Console.WriteLine("Datele angajatilor au fost salvate in fisier.");
            }
        }
    }
