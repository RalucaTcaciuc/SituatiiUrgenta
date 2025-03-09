using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SituatiiUrgenta
{
    public class Urgente
    {
        const string FisierUrgente = "urgente.txt";
        private string oras;
        private string strada;
        private int nr;

        public Urgente()
        {
            oras = string.Empty;
            strada = string.Empty;
            nr = 1;
        }

        public Urgente(string oras, string strada, int nr)
        {
            if (nr <= 0)
                throw new ArgumentException("Numarul cladirii trebuie sa fie pozitiv.");

            this.oras = oras;
            this.strada = strada;
            this.nr = nr;
        }

        public string Info()
        {
            return $"{oras},{strada},{nr}";
        }
        public static Urgente FromString(string linie)
        {
            string[] parts = linie.Split(',');
            if (parts.Length != 3) return null;
            return new Urgente(parts[0], parts[1], int.Parse(parts[2]));
        }

        public static void AdaugaUrgenta(List<Urgente> urgente)
        {
            Console.Write("Introdu orasul: ");
            string oras = Console.ReadLine() ?? string.Empty;

            Console.Write("Introdu strada: ");
            string strada = Console.ReadLine() ?? string.Empty;

            int nr;

            while (true)
            {
                Console.Write("Introdu numarul cladirii: ");
                if (int.TryParse(Console.ReadLine(), out nr) && nr > 0)
                    break;
                else
                    Console.WriteLine("Numarul trebuie sa fie un numar pozitiv!");
            }

            urgente.Add(new Urgente(oras, strada, nr));
            Console.WriteLine("Urgenta a fost adaugata cu succes!");
        }


        public static void AfiseazaUrgente(List<Urgente> urgente)
        {
            if (urgente.Count == 0)
            {
                Console.WriteLine("Nu exista urgente.");
                return;
            }

            Console.WriteLine("\nLista Urgentelor:");
            foreach (var u in urgente)
            {
                Console.WriteLine(u.Info());
            }
        }


        public static void CautaUrgenta(List<Urgente> urgente)
        {
            Console.Write("Introdu orasul cautat: ");
            string orasCautat = Console.ReadLine() ?? string.Empty;

            var rezultate = urgente.Where(u => u.Info().Contains(orasCautat, StringComparison.OrdinalIgnoreCase)).ToList();

            if (rezultate.Count == 0)
            {
                Console.WriteLine("Nicio urgenta gasita.");
                return;
            }

            Console.WriteLine("\nUrgente gasite:");
            foreach (var u in rezultate)
            {
                Console.WriteLine(u.Info());
            }
        }


        public static List<Urgente> CitesteUrgenteDinFisier()
        {
            List<Urgente> urgente = new List<Urgente>();
            if (File.Exists(FisierUrgente))
            {
                foreach (var linie in File.ReadAllLines(FisierUrgente))
                {
                    Urgente u = Urgente.FromString(linie);
                    if (u != null) urgente.Add(u);
                }
            }
            return urgente;
        }

        public static void ScrieUrgenteInFisier(List<Urgente> urgente)
        {
            File.WriteAllLines(FisierUrgente, urgente.Select(u => u.Info()));
            Console.WriteLine("Datele au fost salvate in fisier.");
        }
    }
}