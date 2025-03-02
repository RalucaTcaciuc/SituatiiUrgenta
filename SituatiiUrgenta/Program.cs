using System;

namespace SituatiiUrgenta
{
    class Program
    {
        static void Main()
        {
            Angajat angajat = new("Tcaciuc Raluca-Amalia", 19, "Politist", 2, "tcaciucraluca@gmail.com");
            Console.WriteLine(angajat.Info());

            Console.Write("Introduceti numele angajatului: ");
            string nume = Console.ReadLine();

            Console.Write("Introduceti vârsta angajatului: ");
            int varsta = int.Parse(Console.ReadLine());

            Console.Write("Introduceti specializarea angajatului: ");
            string specializare = Console.ReadLine();

            Console.Write("Introduceti vechimea angajatului (în ani): ");
            int vechime = int.Parse(Console.ReadLine());

            Console.Write("Introduceti email-ul angajatului: ");
            string email = Console.ReadLine();

            Angajat angajat1 = new(nume, varsta, specializare, vechime, email);

            Console.WriteLine("\nAngajatul a fost adaugat cu succes:");
            Console.WriteLine(angajat1.Info());
            Console.ReadKey();
        }
    }
}
