using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SituatiiUrgenta
{
    public class Persoana
    {
        string nume;
        int varsta;
        public Persoana()
        {
            nume = string.Empty;
            varsta = 0;
        }
        public Persoana(string _nume, int _varsta)
        {
            nume = _nume;
            varsta = _varsta;
        }
        public virtual string Info()
        {
            return $"Nume:{nume}, \nVarsta:{varsta}, ";
        }
    }

}
