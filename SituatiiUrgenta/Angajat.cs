using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SituatiiUrgenta
{
    public class Angajat : Persoana
    {
        private string profesie;
        private int vechime;
        private string email;

        public Angajat() : base()
        {
            profesie = string.Empty;
            vechime = 0;
            email = string.Empty;
        }
        public Angajat(string nume, int varsta, string specializare, int vechime, string email) : base(nume, varsta)
        {
            this.profesie = specializare;
            this.vechime = vechime;
            this.email = email;
        }
        public string Info()
        {
            return base.Info() + $"\nProfesie: {profesie}, \nVechime: {vechime}, \nEmail:{email}";
        }
    }

}
