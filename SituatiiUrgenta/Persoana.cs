using System;

namespace SituatiiUrgenta
{
    public class Persoana
    {
        string nume;
        DateTime dataNasterii;

        public Persoana()
        {
            nume = string.Empty;
            this.dataNasterii = DateTime.MinValue;
        }

        public Persoana(string _nume, DateTime _dataNasterii)
        {
            nume = _nume;
            this.dataNasterii = _dataNasterii;
        }

        public virtual string Info()
        {
            return $"{nume},{dataNasterii:dd/MM/yyyy}";
        }

        public string GetNume() => nume;
    }
}
